using UnityEngine;
using UnityEngine.UI;

public class IconColorChanger : MonoBehaviour
{
    [SerializeField] private Color nodeColor;
    [SerializeField] private Color pictureColor;
    [SerializeField] private Color videoColor;
    [SerializeField] private Color soundColor;
    [SerializeField] private Color textColor;

    private void Start()
    {
        // Find all child objects of the canvas
        foreach (Transform child in transform)
        {
            // Check if the child object has the specified script components attached
            if (child.GetComponent<Node>() != null)
            {
                ChangeIconColor(child, nodeColor);
            }
            else if (child.GetComponent<Picture>() != null)
            {
                ChangeIconColor(child, pictureColor);
            }
            else if (child.GetComponent<Video>() != null)
            {
                ChangeIconColor(child, videoColor);
            }
            else if (child.GetComponent<Sound>() != null)
            {
                ChangeIconColor(child, soundColor);
            }
            else if (child.GetComponent<Text>() != null)
            {
                ChangeIconColor(child, textColor);
            }
        }
    }

    private void ChangeIconColor(Transform parentObject, Color color)
    {
        // Iterate through the children of the parent object
        foreach (Transform child in parentObject)
        {
            // Change the color of the UI image to the specified color
            Image iconImage = child.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.color = color;
            }
        }
    }
}
