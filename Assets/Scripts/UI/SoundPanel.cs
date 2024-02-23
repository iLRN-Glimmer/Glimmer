using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundPanel : MonoBehaviour
{
    private GameObject SoundTitle;
    private GameObject SoundDesc;
    private GameObject Sound;

    // Start is called before the first frame update
    void Start()
    {
        SoundTitle = transform.Find("SoundTitle").gameObject;
        SoundDesc = transform.Find("SoundDesc").gameObject;
        Sound = transform.Find("PlayAudioButton").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSound(string Title, string Body)
    {

        SoundTitle.GetComponent<TextMeshProUGUI>().text = Title;
        SoundDesc.GetComponent<TextMeshProUGUI>().text = Body;
    }
}
