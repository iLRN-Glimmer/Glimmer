using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible 
{
    [SerializeField] private string Title;
    [SerializeField] private string Body;
    [SerializeField] private int Status;
    [SerializeField] private string Custom;

    public Collectible(string title, string body, int status, string custom){
        Title = title;
        Body = body;
        Status = status;
        Custom = custom;
    }

    public string GetTitle(){
        return Title;
    }

    public string GetBody()
    {
        return Body;
    }

    public string GetCustom()
    {
        return Custom;
    }

    public int GetStatus()
    {
        return Status;
    }

    public void SetTitle(string s)
    {
        Title = s;
    }

    public void SetBody(string s)
    {
        Body = s;
    }

    public void SetCustom(string s)
    {
        Custom = s;
    }

    public void SetStatus(int i)
    {
        Status = i;
    }
}
