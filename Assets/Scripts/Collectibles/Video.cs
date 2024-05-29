using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : Collectible
{
    [SerializeField] private string Vid;

    public Video(string title, string body, int status, string vid, string custom = null) : base(title, body, status, custom)
    {
        Vid = vid;
    }

    public string GetVid()
    {
        return Vid;
    }

    public void SetVid(string l)
    {
        Vid = l;
    }

    public override void PrintTraits()
    {
        Debug.LogFormat("Title: {0}, \nBody: {1}, \nStatus: {2}, \nCustom: {3}, \nVid: {4},\n", GetTitle(), GetBody(), GetStatus(), GetCustom(), Vid);
    }

    public override void OpenWindow(GameObject canvas)
    {
        GameObject temp = canvas.transform.Find("Video").gameObject;
        temp.SetActive(true);
        temp.transform.Find("VideoPanel").gameObject.GetComponent<VideoPanel>().setVideo(Title, Body, Next,Vid,this);
    }
}
