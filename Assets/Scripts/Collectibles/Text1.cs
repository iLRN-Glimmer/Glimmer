using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : Collectible
{
    public Text1(string title, string body, int status, string custom = null) : base(title, body, status, custom){

    }

    public override void OpenWindow(GameObject canvas)
    {
        GameObject temp = canvas.transform.Find("Text").gameObject;
        temp.SetActive(true);
        temp.transform.Find("TextPanel").gameObject.GetComponent<TextPanel>().setText(Title, Body,Next,this);
    }
}
