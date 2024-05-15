using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class VideoPanel : MonoBehaviour
{
    private GameObject VideoTitle;
    private GameObject VideoDescription;
    private GameObject Vid;
    private GameObject Parent;
    private List<GameObject> children;
    private Collectible Next;

    // Start is called before the first frame update
    void Awake()
    {
        VideoTitle = transform.Find("VideoTitle").gameObject;
        Vid = transform.Find("Video Player").gameObject;
        Parent = transform.parent.gameObject;

        children = new List<GameObject>();
        AddDescendants(transform, children);
        children.Add(gameObject);

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
                    GameObject.Find("Inventory").GetComponent<InventoryPanel>().setOpenedCollectible(false);
                } else {
                    GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().Unpause();
                }
                Parent.SetActive(false);
    

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

    private void OnEnable(){
        transform.Find("VideoDesc").gameObject.SetActive(false);
        transform.Find("Video Player").gameObject.SetActive(true);
    }

    public void setVideo(string Title, string Body, Collectible Next)
    {
        this.Next = Next;
        VideoTitle.GetComponent<TextMeshProUGUI>().text = Title;
        //ImageDescription.GetComponent<TextMeshProUGUI>().text = Body;
    }

    public void openNext()
    {
        if(Next == null){
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
}
