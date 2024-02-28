using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideFromRightPanel : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    public float slideDuration = 0.5f;
    public Vector2 slideOutPosition = new Vector2(-130f, 100f);

    private void OnEnable()
    {
        // Ensure panel is initially at the right side of the screen
        panel.anchoredPosition = new Vector2(Screen.width, 0);

        // Slide the panel in from the right side to the specific position
        LeanTween.move(panel, slideOutPosition, slideDuration).setEase(LeanTweenType.easeOutExpo);
    }
}
