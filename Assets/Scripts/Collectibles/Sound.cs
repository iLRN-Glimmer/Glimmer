using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : Collectible
{
    [SerializeField] private AudioClip Audio;

    public Sound(string title, string body, int status, string custom = null) : base(title, body, status, custom)
    {

    }

    public override void OpenWindow(GameObject canvas)
    {
        GameObject temp = canvas.transform.Find("Sound").gameObject;
        temp.SetActive(true);
        temp.transform.Find("SoundPanel").gameObject.GetComponent<SoundPanel>().setSound(Title, Body,Next,this);
    }

    public AudioClip GetAudio(){
        return Audio;
    }

    public void SetAudio(AudioClip audio)
    {
        Audio = audio;
    }

    private void Start()
    {
        Status = 0;
        //if (!Next)
        //{
        //    Status = PlayerPrefs.GetInt(Title + "Sound");
        //}
        //else
        //{
        //    Next.SetStatus(PlayerPrefs.GetInt(Next.GetTitle() + "Node"));
        //}

    }
}
