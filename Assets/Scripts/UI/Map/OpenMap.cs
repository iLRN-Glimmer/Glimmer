using UnityEngine;

public class OpenMap : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to activate/deactivate

    void Start()
    {
        // Ensure that the panel is initially deactivated
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the "M" key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Call the ActivatePanel method
            ActivatePanel();
        }
    }

    public void ActivatePanel()
    {
        // Toggle the activation state of the panel
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
