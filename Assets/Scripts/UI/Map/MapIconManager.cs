using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class MapIconManager : MonoBehaviour
{
    public TMP_Dropdown dropdownMenu;
    public GameObject[] allMapIcons;
    public GameObject[] unexploredMapIcons;
    public GameObject[] nodesMapIcons;
    public GameObject[] imagesMapIcons;
    public GameObject[] textMapIcons;
    public GameObject[] videoMapIcons;
    public GameObject[] soundMapIcons;

    private void Start()
    {
        dropdownMenu.onValueChanged.AddListener(DropdownValueChanged);
        
        // Populate the arrays
        PopulateArrays();
    }

    private void PopulateArrays()
    {
        // Assuming each type of map icon is stored in a child GameObject
        // You can adjust this logic based on how you organize your map icons
        allMapIcons = GetAllMapIcons(); // all map icons must be tagged MapIcon
        unexploredMapIcons = GetUnexploredMapIcons(); // since can overlap with below lists, separate method
        nodesMapIcons = GetMapIconsByType("Node"); // sort the collectibles by script name (returns array of associated objects)
        imagesMapIcons = GetMapIconsByType("Picture");
        textMapIcons = GetMapIconsByType("Text"); // TODO: doesn't work for text for some reason
        videoMapIcons = GetMapIconsByType("Video");
        soundMapIcons = GetMapIconsByType("Sound");
    }

    private GameObject[] GetAllMapIcons()
    {
        // Retrieve all map icons from the scene
        return GameObject.FindGameObjectsWithTag("MapIcon");
    }

    // create separate lists of different map icon types 
    private GameObject[] GetMapIconsByType(string scriptName)
    {
        List<GameObject> mapIconChildren = new List<GameObject>();

        // Find all GameObjects with the specified script component
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            // check if the game object has the script corresponding to the type
            if (obj.GetComponent(scriptName) != null)
            {
                // Get all children of the GameObject
                foreach (Transform childTransform in obj.transform)
                {
                    // Check if the child has an Image component (assuming UI Image represents map icon)
                    Image imageComponent = childTransform.GetComponent<Image>();
                    if (imageComponent != null)
                    {   
                        // add the child with the image component (presumably map icon) to the list
                        mapIconChildren.Add(childTransform.gameObject);
                    }
                }
            }
        }

        return mapIconChildren.ToArray(); // Convert List<GameObject> to GameObject[];
    }

    //TODO: get unexplored map icons does not work
    private GameObject[] GetUnexploredMapIcons()
    {
        List<GameObject> unexploredMapIcons = new List<GameObject>();

        // Find all GameObjects with any script component attached
        MonoBehaviour[] allScriptComponents = GameObject.FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour scriptComponent in allScriptComponents)
        {
            // Check if the script component has a "status" variable
            var statusField = scriptComponent.GetType().GetField("status");
            if (statusField != null)
            {
                // Get the value of the "status" variable
                int status = (int)statusField.GetValue(scriptComponent);

                // Check if the status is unexplored (status == 0)
                if (status == 0)
                {
                    // Add the child GameObjects (UI Images) associated with this script component
                    Transform parentTransform = scriptComponent.transform;
                    foreach (Transform childTransform in parentTransform)
                    {
                        if (childTransform.GetComponent<Image>() != null)
                        {
                            unexploredMapIcons.Add(childTransform.gameObject);
                        }
                    }
                }
            }
        }

        return unexploredMapIcons.ToArray();
    }

    private GameObject[] GetAllChildren(GameObject parent)
    {
        // Get all child game objects recursively
        var children = new System.Collections.Generic.List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
        }
        return children.ToArray();
    }

    // Method to handle dropdown value change
    private void DropdownValueChanged(int value)
    {
        switch (value)
        {
            case 0: // All
                ShowMapIcons(allMapIcons);
                break;
            case 1: // Unexplored
                ShowMapIcons(unexploredMapIcons);
                break;
            case 2: // Nodes
                ShowMapIcons(nodesMapIcons);
                break;
            case 3: // Images
                ShowMapIcons(imagesMapIcons);
                break;
            case 4: // Text
                ShowMapIcons(textMapIcons);
                break;
            case 5: // Video
                ShowMapIcons(videoMapIcons);
                break;
            case 6: // Sound
                ShowMapIcons(soundMapIcons);
                break;
            default:
                break;
        }
    }


    // Method to show/hide map icons based on selected array
    private void ShowMapIcons(GameObject[] mapIcons)
    {
        // Hide all map icons first
        HideAllMapIcons();

        // Show only the selected map icons
        foreach (GameObject icon in mapIcons)
        {
            icon.SetActive(true);
        }
    }

    // Method to hide all map icons
    private void HideAllMapIcons()
    {
        foreach (GameObject icon in allMapIcons)
        {
            icon.SetActive(false);
        }
    }

}
