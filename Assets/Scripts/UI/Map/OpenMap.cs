using UnityEngine;

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
            // If mapObject is not null, activate it and its children
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }
}
