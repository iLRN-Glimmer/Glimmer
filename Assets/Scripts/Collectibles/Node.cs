using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Node : Collectible
{
    [SerializeField] private string Question;
    [SerializeField] private string Answer;
    [SerializeField] private string URL;
    [SerializeField] private Collectible Collectible;
    [SerializeField] private List<string> Tags;
    [SerializeField] private List<Image> Images;


    public Node(string title, string body, int status, string question, string answer, string url, List<string> tags = null, List<Image> images = null,Collectible collectible = null, string custom = null) : base(title,body,status, custom){
        Question = question;
        Answer = answer;
        URL = url;
        Tags =tags;
        Images = images;
        Collectible = collectible;
    }

    public Collectible GetCollectible(){
        return Collectible;
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

    public void SetCollectible( Collectible collectible){
        Collectible = collectible;
    }

    public override void PrintTraits()
    {
        
        Debug.LogFormat("Title: {0}, \nBody: {1}, \nStatus: {2}, \nCustom: {3}, \nQuestion: {4}, \nAnswer: {5}, \nURL: {6}, \nTag: {7}, \n", GetTitle(), GetBody(), GetStatus(), GetCustom(), Question, Answer, URL, Tags[0]);
    }
}
