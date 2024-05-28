using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject cursorObject; // The existing cursor object in the scene
    public float maxDistance = 100f; // Maximum distance for the raycast

    void Start()
    {
        if (cursorObject != null)
        {
            // Ensure the cursor object is initially deactivated
            cursorObject.SetActive(false);
        }
    }

    void Update()
    {
        // Perform a raycast from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Check if the object hit by the raycast has the 'Selectable' tag
            if (hit.collider.CompareTag("Selectable"))
            {
                // If so, activate and position the cursor object in the middle of the screen
                if (cursorObject != null)
                {
                    cursorObject.SetActive(true);
                }
            }
            else
            {
                // Deactivate the cursor object if the raycast does not hit a 'Selectable' object
                if (cursorObject != null)
                {
                    cursorObject.SetActive(false);
                }
            }
        }
        else
        {
            // Deactivate the cursor object if the raycast does not hit anything
            if (cursorObject != null)
            {
                cursorObject.SetActive(false);
            }
        }
    }
}
