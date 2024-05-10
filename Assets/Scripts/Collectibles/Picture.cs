using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : Collectible
{
    [SerializeField] private List<Sprite> Images;

    public Picture(string title, string body, int status, List<Sprite> images , string custom = null) : base(title, body, status, custom)
    {
        Images = images;
    }

    public List<Sprite> GetImages()
    {
        return Images;
    }

    public void SetImages(List<Sprite> l)
    {
        Images = l;
    }

    public override void PrintTraits()
    {
        Debug.LogFormat("Title: {0}, \nBody: {1}, \nStatus: {2}, \nCustom: {3}, \nImage: {4},\n", GetTitle(), GetBody(), GetStatus(), GetCustom(), Images[0]);
    }

    public override void OpenWindow(GameObject canvas)
    {
        GameObject temp = canvas.transform.Find("Image").gameObject;
        temp.SetActive(true);
        temp.transform.Find("ImagePanel").gameObject.GetComponent<ImagePanel>().setImage(Title, Body, Next, Images);

    }

    
}
