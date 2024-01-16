using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Node : Collectible
{
    string Question;
    string Answer;
    string URL;
    List<string> Tags;
    List<Image> Images;


    public Node(string title, string body, string status, string question, string answer, string url, List<string> tags = null, List<Image> images = null, string custom = null) : base(title,body,status, custom){
        Question = question;
        Answer = answer;
        URL = url;
        Tags =tags;
        Images = images;
    }
}
