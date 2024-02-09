using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Collectible : MonoBehaviour 
{
    [SerializeField] protected string Title;
    [SerializeField] protected string Body;
    [SerializeField] protected int Status;
    [SerializeField] protected string Custom;

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

    public virtual void PrintTraits(){
        Debug.LogFormat("Title: {0}, \nBody: {1}, \nStatus: {2}, \nCustom: {3},\n", Title, Body, Status, Custom);
    }

    public virtual void OpenWindow(GameObject canvas){

    }
}
