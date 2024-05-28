using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;
using System.Linq;
using System.Collections.Generic;

public class OpenHelp : MonoBehaviour
{
    [SerializeField]
    private GameObject panel; // Reference to the panel you want to activate/deactivate
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
        // Check if the "Tab" key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab key pressed!");

            if (panel != null)
            {
                // If the panel is currently inactive, activate it
                //find freeze state
                freezed = GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().GetFreeze();

                // Toggle the active state of the panel
                if (!panel.activeSelf)
                {
                    if (!freezed)
                    {
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

        // Check for mouse click outside the panel
        if (Input.GetMouseButtonDown(0) && !IsPointerOverPanel())
        {
            // Close the panel
            if (panel != null && panel.activeSelf)
            {
                GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().Unpause();
                panel.GetComponent<DialogBox>().CloseDialog();
            }
        }
    }

    // Check if the mouse is over the specified panel
    private bool IsPointerOverPanel()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Raycast to determine if the pointer is over a UI object
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // Check if the UI object under the pointer is a child of the panel's parent GameObject
        return results.Any(result => result.gameObject.transform.IsChildOf(panel.transform));
    }
}
