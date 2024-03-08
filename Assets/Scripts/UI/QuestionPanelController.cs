using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject panel; // Reference to your panel GameObject
    [SerializeField]
    private GameObject desc;
    [SerializeField]
    private GameObject button;

    private List<GameObject> children;

    private void Start() {
        children  = new List<GameObject>();
        AddDescendants(panel.transform,children);
        children.Add(panel);
    }

    private void AddDescendants(Transform parent, List<GameObject> list){
        foreach (Transform child in parent)
        {
            list.Add(child.gameObject);
            AddDescendants(child, list);
        }
    }
    private void Update()
    {
        // Check for mouse click outside the panel
        if (Input.GetMouseButtonDown(0) && !IsPointerOverPanel())
        {
            // If the panel is active, close it
            if (panel.activeSelf)
            {
                panel.SetActive(false);
                desc.SetActive(true);
                button.SetActive(true);
                
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

        // Check if the UI object under the pointer is the specified panel
        return results.Count > 0 && children.Contains(results[0].gameObject);
    }

    // Method to open or close the panel
    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
