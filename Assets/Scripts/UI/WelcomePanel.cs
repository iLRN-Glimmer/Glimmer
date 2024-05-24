using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class WelcomePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject help;

    private List<GameObject> children;

    void Start()
    {
        children = new List<GameObject>();
        AddDescendants(transform, children);
        children.Add(gameObject);
    }

    void Update()
    {
        // Check for mouse click outside the panel
        if (Input.GetMouseButtonDown(0) && !IsPointerOverPanel())
        {
            // If the panel is active, close it
            if (panel.activeSelf)
            {
                ClosePanel();
                help.SetActive(true);
            }
        }
    }

    // Check if the mouse is over the specified panel or its children
    private bool IsPointerOverPanel()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Raycast to determine if the pointer is over a UI object
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // Check if any UI object under the pointer is within the panel or its children
        foreach (RaycastResult result in results)
        {
            if (children.Contains(result.gameObject))
            {
                return true;
            }
        }

        return false;
    }

    // Method to close the panel
    private void ClosePanel()
    {
        panel.SetActive(false);
    }

    // Recursively add all descendants of the specified parent to the list
    private void AddDescendants(Transform parent, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            list.Add(child.gameObject);
            AddDescendants(child, list);
        }
    }
}
