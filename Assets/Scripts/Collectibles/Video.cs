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
}
