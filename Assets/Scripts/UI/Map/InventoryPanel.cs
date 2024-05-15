using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private Transform box;

    private bool openedCollectible;

    private void OnEnable()
    {
        // Move the panel on screen
        box.localPosition = new Vector2(-570, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
        openedCollectible = false;
        Debug.Log("opened collectible is false");
    }

    public void CloseDialog()
    {
        // move panel outside of view
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
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
        } else {
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
