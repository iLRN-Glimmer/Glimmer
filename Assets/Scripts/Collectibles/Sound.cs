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
        canvas.transform.Find("SoundPanel").gameObject.SetActive(true);
    }
}
