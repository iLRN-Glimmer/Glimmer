using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VideoPanel : MonoBehaviour
{
    private GameObject VideoTitle;
    private GameObject VideoDescription;
    private GameObject Vid;

    // Start is called before the first frame update
    void Start()
    {
        VideoTitle = transform.Find("VideoTitle").gameObject;
        Vid = transform.Find("Video Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable(){
        transform.Find("VideoDesc").gameObject.SetActive(false);
        transform.Find("Video Player").gameObject.SetActive(true);
    }

    public void setVideo(string Title, string Body)
    {

        VideoTitle.GetComponent<TextMeshProUGUI>().text = Title;
        //ImageDescription.GetComponent<TextMeshProUGUI>().text = Body;
    }
}
