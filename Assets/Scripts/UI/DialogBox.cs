using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [SerializeField]
    private Transform box;
    [SerializeField]
    private CanvasGroup background;

    private AudioSource ClosePanel;

    private void OnEnable() {

        // set transparency of background to 0
        background.alpha = 0;
        // change transparency of background
        LeanTweenExt.LeanAlpha(background, 1, 0.5f);
        // background.LeanAlpha(1, 0.5f);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
        // box.LeanMoveLocalY(0, 0.5f).setEase; // look at bouncing effect for setEase

        ClosePanel = GameObject.Find("PanelsCanvas").GetComponent<AudioSource>();
    }

    public void CloseDialog() {
        // make background transparent
        LeanTweenExt.LeanAlpha(background, 0, 0.5f);
        // background.LeanAlpha(0, 0.5);
        // move screen outside of view
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
        ClosePanel.Play();
    }

    void OnComplete() {
        gameObject.SetActive(false);

    }
}
