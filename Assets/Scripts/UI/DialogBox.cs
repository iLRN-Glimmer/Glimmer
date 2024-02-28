using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [SerializeField]
    private Transform box;
    [SerializeField]
    private CanvasGroup background;

    private void OnEnable() {

        // set transparency of background to 0
        background.alpha = 0;
        // change transparency of background
        LeanTweenExt.LeanAlpha(background, 1, 0.7f);
        // background.LeanAlpha(1, 0.5f);

        box.localPosition = new Vector2(0, -Screen.height);
        LeanTween.moveLocalY(box.gameObject, 0, 0.7f).setEase(LeanTweenType.easeOutExpo).setEaseSpring().setDelay(0.1f);
        // box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog() {
        // make background transparent
        LeanTweenExt.LeanAlpha(background, 0, 0.7f);
        // background.LeanAlpha(0, 0.5);
        // move screen outside of view
        // box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
        LeanTween.moveLocalY(box.gameObject, -Screen.height, 0.7f).setEase(LeanTweenType.easeInExpo).setOnComplete(OnComplete);
    }

    void OnComplete() {
        gameObject.SetActive(false);

    }
}
