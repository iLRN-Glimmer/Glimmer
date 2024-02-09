using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : Collectible
{
    public Text(string title, string body, int status, string custom = null) : base(title, body, status, custom){

    }

    public override void OpenWindow(GameObject canvas)
    {
        GameObject temp = canvas.transform.Find("TextPanel").gameObject;
        temp.SetActive(true);
        temp.GetComponent<TextPanel>().setText(Title, Body);
    }
}
