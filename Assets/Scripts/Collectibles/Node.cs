using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : Collectible
{
    [SerializeField] private string Question;
    [SerializeField] private string Answer;
    [SerializeField] private string URL;
    [SerializeField] private List<string> Tags;
    [SerializeField] private List<Sprite> Images;
    [SerializeField] private string Open;
    [SerializeField] private List<string> Author;
    

    public Node(string title, string body, int status, string question, string answer, string url, List<string> author, List<string> tags = null, List<Sprite> images = null, string custom = null) : base(title,body,status, custom){
        Question = question;
        Answer = answer;
        URL = url;
        Tags =tags;
        Images = images;
        Author = author;
    }

    private void Start() {
        System.DateTime dateTime = System.DateTime.Parse(Open);
        if(DateTime.UtcNow < dateTime){
            gameObject.SetActive(false);
        }
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

    public List<Sprite> GetImages()
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

    public void SetImages(List<Sprite> l)
    {
        Images = l;
    }


    public override void PrintTraits()
    {
        
        Debug.LogFormat("Title: {0}, \nBody: {1}, \nStatus: {2}, \nCustom: {3}, \nQuestion: {4}, \nAnswer: {5}, \nURL: {6}, \nTag: {7}, \n", GetTitle(), GetBody(), GetStatus(), GetCustom(), Question, Answer, URL, Tags[0]);
    }

    public override void OpenWindow(GameObject canvas)
    {
        GameObject temp = canvas.transform.Find("Node").gameObject;
        temp.SetActive(true);
        
        temp.transform.Find("NodePanel").gameObject.GetComponent<NodePanel>().setNode(Title, Body,Question,Answer,URL, Tags, Next, Images,Author,this);
    }
}
