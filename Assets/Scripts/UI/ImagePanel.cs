using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImagePanel : MonoBehaviour
{
    private GameObject ImageTitle;
    private GameObject ImageDescription;
    private GameObject Picture;

    // Start is called before the first frame update
    void Start()
    {
        ImageTitle = transform.Find("ImageTitle").gameObject;
        Picture = transform.Find("Image").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable(){
        transform.Find("ImageDesc").gameObject.SetActive(false);
        transform.Find("Image").gameObject.SetActive(true);
    }

    public void setImage(string Title, string Body)
    {
        
        ImageTitle.GetComponent<TextMeshProUGUI>().text = Title;
        //ImageDescription.GetComponent<TextMeshProUGUI>().text = Body;
    }
}
