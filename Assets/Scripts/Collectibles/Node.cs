using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Node : Collectible
{
    [SerializeField] private string Question;
    [SerializeField] private string Answer;
    [SerializeField] private string URL;
    [SerializeField] private List<string> Tags;
    [SerializeField] private List<Image> Images;


    public Node(string title, string body, int status, string question, string answer, string url, List<string> tags = null, List<Image> images = null, string custom = null) : base(title,body,status, custom){
        Question = question;
        Answer = answer;
        URL = url;
        Tags =tags;
        Images = images;
    }

    public string GetQuestion()
    {
        return Question;
    }

    public string GetAnswer()
    {
        return Answer;
    }

    public string GetURL()
    {
        return URL;
    }

    public List<string> GetTags()
    {
        return Tags;
    }

    public List<Image> GetImages()
    {
        return Images;
    }

    public void SetQuestion(string s)
    {
        Question = s;
    }

    public void SetAnswer(string s)
    {
        Answer = s;
    }

    public void SetURL(string s)
    {
        URL = s;
    }

    public void SetTags(List<string> l)
    {
        Tags = l;
    }

    public void SetImages(List<Image> l)
    {
        Images = l;
    }
}
