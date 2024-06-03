using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StarterAssets;

public class ImagePanel : MonoBehaviour
{
    private GameObject ImageTitle;
    private GameObject ImageDesc;
    private GameObject Picture;
    private GameObject Parent;
    private List<GameObject> children;
    private Collectible Next;
    private int index;
    private List<Sprite> imageList;
    private GameObject NextButton;
    private Picture picture;

    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button rightButton;


    // Start is called before the first frame update
    void Awake()
    {
        

        children = new List<GameObject>();
        AddDescendants(transform, children);
        children.Add(gameObject);

        ImageTitle = transform.Find("ImageTitle").gameObject;
        ImageDesc = transform.Find("ImageDesc").gameObject;
        Picture = transform.Find("Image").gameObject;
        Parent = transform.parent.gameObject;
        index = 0;
        NextButton = transform.Find("CloseButton").gameObject;
        

        //UpdateButtonVisibility();


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

    private void OnEnable(){
        transform.Find("ImageDesc").gameObject.SetActive(false);
        transform.Find("Image").gameObject.SetActive(true);
    }

    public void setImage(string Title, string Body, Collectible Next, List<Sprite> images, Picture Picture)
    {
        picture =Picture;
        this.Next = Next;
        if (!this.Next){
            NextButton.SetActive(false);
        }else{
            NextButton.SetActive(true);
        }
        ImageTitle.GetComponent<TextMeshProUGUI>().text = Title;
        ImageDesc.GetComponent<TextMeshProUGUI>().text = Body;
        imageList = images;
        UpdateImage();
        UpdateButtonVisibility();
        if(!Next){
            SetStatus();
            PlayerPrefs.SetInt(ImageTitle.GetComponent<TextMeshProUGUI>().text + "Picture", 1);
        }
        
        Debug.Log("set image");
    }

    // Method to decrement the index and update the image
    public void OnLeftButtonClick()
    {
        index--;
        UpdateImage();
        UpdateButtonVisibility();
    }

    // Method to increment the index and update the image
    public void OnRightButtonClick()
    {
        index++;
        UpdateImage();
        UpdateButtonVisibility();
    }

    // Method to update the displayed image based on the current index
    private void UpdateImage()
    {
        Debug.Log("image index " + index);
        if (index >= 0 && index < imageList.Count)
        {
            Picture.GetComponent<Image>().sprite = imageList[index];
        }
        else
        {
            Debug.Log("Index out of range for images list.");
            if (index < 0)
            {
                index = 0;
            }
            else 
            {
                index = imageList.Count;
            }
        }
    }

    // Method to update button visibility based on current index
    private void UpdateButtonVisibility()
    {
        Debug.Log("update button");
        Debug.Log("button index " + index);
        if (index <= 0)
        {
            leftButton.gameObject.SetActive(false);
        }
        else
        {
            leftButton.gameObject.SetActive(true);
        }

        if (index >= imageList.Count - 1)
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
        }
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
        return picture.GetStatus();
    }

    public void SetStatus()
    {
        picture.SetStatus(1);
    }
}
