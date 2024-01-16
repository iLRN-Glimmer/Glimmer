using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Picture : Collectible
{
    Image Image;

    public Picture(string title, string body, string status, string custom, Image image) : base(title, body, status, custom)
    {
        Image = image;
    }
}
