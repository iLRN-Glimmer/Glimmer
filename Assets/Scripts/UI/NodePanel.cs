using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NodePanel : MonoBehaviour
{
    private GameObject NodeTitle;
    private GameObject NodeDescription;
    private GameObject NodeThumbnail;
    private GameObject NodeQuestion;
    private string Answer;

    // Start is called before the first frame update
    void Start()
    {
        NodeTitle = transform.Find("NodeTitle").gameObject;
        NodeDescription = transform.Find("NodeDescription").gameObject;
        NodeThumbnail = transform.Find("NodeThumbnail").gameObject;
        NodeQuestion = transform.Find("Question/NodeQuestion").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        this.transform.Find("Question").gameObject.SetActive(false);
        transform.Find("NodeDescription").gameObject.SetActive(true);
    }

    public void setNode(string Title, string Body, string Question, string Answer)
    {
        NodeTitle.GetComponent<TextMeshProUGUI>().text = Title;
        NodeDescription.GetComponent<TextMeshProUGUI>().text = Body;
        NodeQuestion.GetComponent<TextMeshProUGUI>().text = Question;
        this.Answer = Answer;
    }
}
