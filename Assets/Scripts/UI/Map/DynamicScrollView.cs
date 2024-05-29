using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DynamicScrollView : MonoBehaviour
{
    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private GameObject prefab;

    private List<GameObject> collected;

    public TMP_Dropdown filterDropdown;

    private void Start()
    {

        // Subscribe to the dropdown's OnValueChanged event to handle filtering
        filterDropdown.onValueChanged.AddListener(FilterInventory);

        // Collect objects and populate the scroll view initially
        CollectObjects();
        PopulateScrollView(collected);
    }
    
    private void OnEnable() {
        CollectObjects();
        FilterInventory(0);
    }

    private void CollectObjects()
    {
        // Find all game objects tagged as "Selectable"
        GameObject[] selectableObjects = GameObject.FindGameObjectsWithTag("Selectable");

        // List to store filtered objects
        List<GameObject> filteredObjects = new List<GameObject>();
        // Loop through each selectable object
        foreach (GameObject obj in selectableObjects)
        {
            
            // Get the status of the collectible object
            int status = obj.GetComponent<Collectible>().GetStatus();
            
            Debug.Log(obj + " Then " + status);
            

            if (status == 1)
            {
                // Add the object to the filtered list
                filteredObjects.Add(obj);
            }
        }

        collected = filteredObjects;
    }

    private void PopulateScrollView(List<GameObject> objects)
    {
        foreach (GameObject collectible in objects)
        {
            GameObject newCollectible = Instantiate(prefab, scrollViewContent);
            if (newCollectible.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
            {
                // Get title and type from collectible object
                string title = collectible.GetComponent<Collectible>().GetTitle();
                string type = collectible.GetComponent<Collectible>().GetType().Name;
                item.ChangeInventory(title, type, collectible);
            }
        }
    }

    private void FilterInventory(int dropdownIndex)
    {
        // Clear the scroll view content
        foreach (Transform child in scrollViewContent)
        {
            Destroy(child.gameObject);
        }

        // Apply filtering based on the selected dropdown option
        switch (dropdownIndex)
        {
            case 0: // All
                PopulateScrollView(collected);
                break;
            case 1: // Node
                PopulateScrollView(collected.FindAll(obj => obj.GetComponent<Collectible>().GetType().Name == "Node"));
                break;
            case 2: // Text
                PopulateScrollView(collected.FindAll(obj => obj.GetComponent<Collectible>().GetType().Name == "Text1"));
                break;
            case 3: // Video
                PopulateScrollView(collected.FindAll(obj => obj.GetComponent<Collectible>().GetType().Name == "Video"));
                break;
            case 4: // Picture
                PopulateScrollView(collected.FindAll(obj => obj.GetComponent<Collectible>().GetType().Name == "Picture"));
                break;
            case 5: // Sound
                PopulateScrollView(collected.FindAll(obj => obj.GetComponent<Collectible>().GetType().Name == "Sound"));
                break;
        }
    }
}
