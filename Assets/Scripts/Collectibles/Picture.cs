using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Picture : Collectible
{
    [SerializeField] private List<Image> Images;

    public Picture(string title, string body, int status, string custom, List<Image> images) : base(title, body, status, custom)
    {
        Images = images;
    }

    public List<Image> GetImages()
    {
        return Images;
    }

    public void SetImages(List<Image> l)
    {
        Images = l;
    }
}
