using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class SoundPanel : MonoBehaviour
{
    private GameObject SoundTitle;
    private GameObject SoundDesc;
    private GameObject Sound;
    private GameObject Parent;
    private List<GameObject> children;
    private Collectible Next;
    private GameObject NextButton;
    private Sound sound;
    private AudioClip clip;
    

    // Start is called before the first frame update
    void Awake()
    {
        

        children = new List<GameObject>();
        AddDescendants(transform, children);
        children.Add(gameObject);

        SoundTitle = transform.Find("SoundTitle").gameObject;
        SoundDesc = transform.Find("SoundDesc").gameObject;
        Sound = transform.Find("PlayAudioButton").gameObject;
        Parent = transform.parent.gameObject;
        NextButton = transform.Find("CloseButton").gameObject;

    }

    private void AddDescendants(Transform parent, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            list.Add(child.gameObject);
            AddDescendants(child, list);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click outside the panel
        if (Input.GetMouseButtonDown(0) && !IsPointerOverPanel())
        {
            // If the panel is active, close it
            if (Parent.activeSelf)
            {
                // check if opened panel is on map and don't unpause screen if so
                GameObject map = GameObject.Find("Map");
                if(map && map.activeSelf)
                {
                    //BUG
                    // GameObject.Find("Inventory").GetComponent<InventoryPanel>().setOpenedCollectible(false);
                } else {
                    GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().Unpause();
                }
                Parent.GetComponent<DialogBox>().CloseDialog();
    

            }
        }
    }

    // Check if the mouse is over the specified panel
    private bool IsPointerOverPanel()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Raycast to determine if the pointer is over a UI object
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // Check if the UI object under the pointer is the specified panel
        return results.Count > 0 && children.Contains(results[0].gameObject);
    }

    public void setSound(string Title, string Body, Collectible Next, Sound play)
    {
        sound = play;
        clip = play.GetAudio();
        
        SoundTitle.GetComponent<TextMeshProUGUI>().text = Title;
        SoundDesc.GetComponent<TextMeshProUGUI>().text = Body;
        this.Next = Next;
        if (!this.Next)
        {
            NextButton.SetActive(false);
        }
        else
        {
            NextButton.SetActive(true);
        }
        if (!Next)
        {
            SetStatus();
            PlayerPrefs.SetInt(SoundTitle.GetComponent<TextMeshProUGUI>().text + "Sound", 1);
        }

        AudioSource speaker = Sound.transform.GetComponent<AudioSource>();
        speaker.clip = clip;
    }

    public void openNext()
    {
        if (Next == null)
        {
            return;
        }
        var canvas = GameObject.Find("PanelsCanvas");
        Next.OpenWindow(canvas);

        if (Parent.activeSelf)
        {
            //GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().Unpause();
            Parent.SetActive(false);

        }
    }

    public int GetStatus()
    {
        return sound.GetStatus();
    }

    public void SetStatus()
    {
        sound.SetStatus(1);
    }

    public void PlaySound(){
        AudioSource speaker = Sound.transform.GetComponent<AudioSource>();
        speaker.Play(0);
    }

}
