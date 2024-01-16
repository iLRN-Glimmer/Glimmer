using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible 
{
    string Title;
    string Body;
    string Status;
    string Custom;

    public Collectible(string title, string body, string status, string custom){
        Title = title;
        Body = body;
        Status = status;
        Custom = custom;
    }
}
