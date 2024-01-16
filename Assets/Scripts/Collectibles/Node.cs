using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Collectible
{
    string Question;
    string Answer;
    string URL;

    public Node(string title, string body, string question, string answer, string url) : base(title,body){
        Question = question;
        Answer = answer;
        URL = url;
    }
}
