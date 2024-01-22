using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : Collectible
{
    [SerializeField] private Video Vid;

    public Video(string title, string body, int status, string custom, Video vid) : base(title, body, status, custom)
    {
        Vid = vid;
    }

    public Video GetVid()
    {
        return Vid;
    }

    public void SetVid(Video l)
    {
        Vid = l;
    }

    public override void PrintTraits()
    {
        Debug.LogFormat("Title: {0}, \nBody: {1}, \nStatus: {2}, \nCustom: {3}, \nVid: {4},\n", GetTitle(), GetBody(), GetStatus(), GetCustom(), Vid);
    }
}
