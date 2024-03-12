using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;
using StarterAssets;

public class NodePanel : MonoBehaviour
{
    private GameObject NodeTitle;
    private GameObject NodeDescription;
    private GameObject NodeThumbnail;
    private GameObject NodeQuestion;
    private GameObject Parent;
    private List<GameObject> children;
    private string Answer;
    private string URL;

    // Start is called before the first frame update
    void Start()
    {
        NodeTitle = transform.Find("NodeTitle").gameObject;
        NodeDescription = transform.Find("NodeDescription").gameObject;
        NodeThumbnail = transform.Find("NodeThumbnail").gameObject;
        NodeQuestion = transform.Find("Question/NodeQuestion").gameObject;
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



    private void OnEnable() {
        this.transform.Find("Question").gameObject.SetActive(false);
        transform.Find("NodeDescription").gameObject.SetActive(true);
    }

    public void setNode(string Title, string Body, string Question, string Answer, string URL)
    {
        NodeTitle.GetComponent<TextMeshProUGUI>().text = Title;
        NodeDescription.GetComponent<TextMeshProUGUI>().text = Body;
        NodeQuestion.GetComponent<TextMeshProUGUI>().text = Question;
        this.Answer = Answer;
        this.URL = URL;
    }

    public void openURL(){
        Application.OpenURL(URL);
    }
}
