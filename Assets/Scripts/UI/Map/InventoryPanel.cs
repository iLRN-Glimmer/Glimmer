using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private Transform box;

    private bool openedCollectible;

    // Offset to fine-tune the panel's position when fully visible
    private Vector2 visiblePosition = new Vector2(-550, 0);  // Adjust this based on your UI layout

    // Offset to position the panel off-screen to the left
    private Vector2 offScreenPosition = new Vector2(-Screen.width, 0);  // Adjust this if needed

    private void OnEnable()
    {
        // Move the panel off screen to the left
        box.localPosition = new Vector2(offScreenPosition.x, visiblePosition.y); // Initially set the box off-screen
        // Animate the panel sliding in from the left
        box.LeanMoveLocalX(visiblePosition.x, 0.5f).setEaseOutExpo().delay = 0.1f;
        openedCollectible = false;
        Debug.Log("opened collectible is false");
    }

    public void CloseDialog()
    {
        // Animate the panel sliding out to the left
        box.LeanMoveLocalX(offScreenPosition.x, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click outside the panel
        Debug.Log("update inventory: openedcollectible? " + openedCollectible);
        if (Input.GetMouseButtonDown(0) && !IsPointerOverPanel() && gameObject.activeSelf && !openedCollectible)
        {
            Debug.Log("opened collectible is " + openedCollectible);
            // If the panel is active, close it
            CloseDialog();
        }
        else
        {
            Debug.Log("can't close inventory atm");
        }
    }

    // Check if the mouse is over the panel
    private bool IsPointerOverPanel()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Raycast to determine if the pointer is over a UI object
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // Check if the UI object under the pointer is the panel or its children
        foreach (RaycastResult result in results)
        {
            if (result.gameObject == gameObject || result.gameObject.transform.IsChildOf(transform))
            {
                return true;
            }
        }
        return false;
    }

    void OnComplete()
    {
        gameObject.SetActive(false);
    }

    public void setOpenedCollectible(bool status)
    {
        Debug.Log("open collectible? set to " + status);
        openedCollectible = status;
    }

    public bool getOpenedCollectible()
    {
        return openedCollectible;
    }
}
