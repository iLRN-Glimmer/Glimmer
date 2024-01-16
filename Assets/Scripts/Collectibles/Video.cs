using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : Collectible
{
    Video Vid;

    public Video(string title, string body, string status, string custom, Video vid) : base(title, body, status, custom)
    {
        Vid = vid;
    }
}
