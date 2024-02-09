using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    private GameObject TextTitle;
    private GameObject TextDescription;

    // Start is called before the first frame update
    void Start()
    {
        TextTitle = transform.Find("TextTitle").gameObject;
        TextDescription = transform.Find("Text").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string Title, string Body){
        TextTitle.GetComponent<TextMeshProUGUI>().text = Title;
        TextDescription.GetComponent<TextMeshProUGUI>().text = Body;
    }
}
