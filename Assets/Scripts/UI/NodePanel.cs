using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using System.Linq;

public class NodePanel : MonoBehaviour
{
    private GameObject NodeTitle;
    private GameObject NodeDescription;
    private GameObject NodeThumbnail;
    private GameObject NodeQuestion;
    private GameObject QuestionText;
    private GameObject NodeTags;
    private GameObject Parent;
    private List<GameObject> children;
    private string Answer;
    private string URL;
    private Collectible Next;
    private Node Node;
    
    private int index;
    private List<Sprite> imageList;


    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button rightButton;

    // Start is called before the first frame update
    void Awake()
    {
        NodeTitle = transform.Find("NodeTitle").gameObject;
        NodeDescription = transform.Find("NodeDescription").gameObject;
        NodeThumbnail = transform.Find("NodeThumbnail").gameObject;
        NodeQuestion = transform.Find("Question/NodeQuestion").gameObject;
        QuestionText = transform.Find("Question/NodeAnswerInput").gameObject;
        NodeTags = transform.Find("NodeTags").gameObject;
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
                { //BUG
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



    private void OnEnable() {
        transform.Find("Question").gameObject.SetActive(false);
        transform.Find("NodeDescription").gameObject.SetActive(true);
        transform.Find("QuestionButton").gameObject.SetActive(true);
    }

    public void setNode(string Title, string Body, string Question, string Answer, string URL, List<string> Tags, Collectible Next, List<Sprite> Images, Node node)
    {
        Node = node;
        NodeTitle.GetComponent<TextMeshProUGUI>().text = Title;
        NodeDescription.GetComponent<TextMeshProUGUI>().text = Body;
        NodeQuestion.GetComponent<TextMeshProUGUI>().text = Question;
        string temp = "";
        foreach(string tag in Tags){
            temp = temp+ "#" + tag + " ";
        }
        NodeTags.GetComponent<TextMeshProUGUI>().text = temp;
        this.Answer = Answer;
        this.URL = URL;
        this.Next = Next;
        //Debug.Log(this.Next);

        imageList = Images;
        UpdateImage();
        UpdateButtonVisibility();
        Debug.Log("set image");
    }

    public void openURL(){
        Application.OpenURL(URL);
    }

    public void openNext(){
        if (Next == null)
        {
            return;
        }
        var txt = QuestionText.GetComponent<TMP_InputField>().text.ToLower();
        if(txt != Answer.ToLower()){
            // Trigger the shake animation using LeanTween
            ShakeInputField();
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

    // shake animation for input field incorrect
    void ShakeInputField()
    {
        RectTransform rectTransform = QuestionText.GetComponent<RectTransform>();
        float shakeDuration = 0.2f;
        float shakeStrength = 8f;
        int shakeVibrato = 10;

        LeanTween.moveX(rectTransform, rectTransform.anchoredPosition.x + shakeStrength, shakeDuration / shakeVibrato).setEaseShake().setLoopPingPong(shakeVibrato);
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

             // Assign the texture directly to the RawImage component
            NodeThumbnail.GetComponent<Image>().sprite = imageList[index];
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

    public int GetStatus(){
        return Node.GetStatus();
    }

    public void SetStatus()
    {
        Node.SetStatus(1);
    }

}
