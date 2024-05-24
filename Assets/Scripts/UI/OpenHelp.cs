using UnityEngine;
using StarterAssets;

public class OpenHelp : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to activate/deactivate
    private bool freezed;

    void Start()
    {
        // Ensure that the panel is initially deactivated
        if (panel != null)
        {
            Debug.Log("Help panel object found: " + panel);
            panel.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the "M" key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab key pressed!");

        
            if (panel != null) {
                // If the panel is currently inactive, activate it
                //find freeze state
                freezed = GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().GetFreeze();
                
                // Toggle the active state of the panel
                if (!panel.activeSelf)
                {
                    if(!freezed) {
                        panel.SetActive(true);

                        // Ensure cursor is visible and unlocked
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().SetFreeze();
                        
                    }
                }
                else // If the panel is currently active, deactivate it
                {
                    GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().Unpause();
                    panel.GetComponent<DialogBox>().CloseDialog();
                }
            }
        }
    
}
}
