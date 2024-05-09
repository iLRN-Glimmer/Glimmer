using UnityEngine;
using StarterAssets;

public class OpenMap : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to activate/deactivate

    void Start()
    {
        // Ensure that the panel is initially deactivated
        if (panel != null)
        {
            Debug.Log("Map panel object found: " + panel);
            panel.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the "M" key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M key pressed!");
            // Toggle the active state of the panel
            if (panel != null)
            {
                // If the panel is currently inactive, activate it
                if (!panel.activeSelf)
                {
                    panel.SetActive(true);

                    // Ensure cursor is visible and unlocked
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().SetFreeze();
                }
                else // If the panel is currently active, deactivate it
                {
                    GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().Unpause();
                    panel.SetActive(false);
                }
            }
        }
    }

}
