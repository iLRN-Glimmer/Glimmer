using UnityEngine;
using UnityEngine.UI;

public class LearnMoreToggleScript : MonoBehaviour
{
    public GameObject textObject;
    public GameObject mediaObject;

    public void OnButtonClick()
    {
        // Toggle the visibility of text and image
        textObject.SetActive(!textObject.activeSelf);
        mediaObject.SetActive(!mediaObject.activeSelf);
    }
}
