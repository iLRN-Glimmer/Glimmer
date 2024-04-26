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
    private GameObject ImageDescription;
    private GameObject Picture;
    private GameObject Parent;
    private List<GameObject> children;
    private Collectible Next;
    private int index;
    private List<Image> imageList;

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
        Picture = transform.Find("Image").gameObject;
        Parent = transform.parent.gameObject;
        index = 0;
        
        // UpdateButtonVisibility();

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
                GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().Unpause();
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
        transform.Find("ImageDesc").gameObject.SetActive(false);
        transform.Find("Image").gameObject.SetActive(true);
    }

    public void setImage(string Title, string Body, Collectible Next, List<Image> images)
    {
        this.Next = Next;
        ImageTitle.GetComponent<TextMeshProUGUI>().text = Title;
        //ImageDescription.GetComponent<TextMeshProUGUI>().text = Body;
        imageList = images;
        UpdateImage();
        UpdateButtonVisibility();
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
            Picture.GetComponent<Image>().sprite = imageList[index].sprite;
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
}
