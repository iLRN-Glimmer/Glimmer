using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScrollView : MonoBehaviour
{
    [SerializeField]
    private Transform scrollViewContent;
    
    [SerializeField]
    private GameObject prefab;

    private List<GameObject> collected;

    private void Start() {
        Debug.Log("create inventory");
        // Find all game objects tagged as "Selectable"
        GameObject[] selectableObjects = GameObject.FindGameObjectsWithTag("Selectable");

        // List to store filtered objects
        List<GameObject> filteredObjects = new List<GameObject>();

        // Loop through each selectable object
        foreach (GameObject obj in selectableObjects)
        {
             Debug.Log("find collectible");

            // where is get status?? how to get the status 
            //--> getting it by searching for a script and 
            // then checking status var did not work
            // if(obj.GetStatus() = 1){
            //     Debug.Log("collected status = 1");
            //     // Add the object to the filtered list
            //     filteredObjects.Add(obj);
            // }
    
        }

        collected = filteredObjects;

        Debug.Log("looping through collected");

        foreach (GameObject collectible in collected)
        {
            Debug.Log("collected: " + collectible);
            GameObject newCollectible = Instantiate(prefab, scrollViewContent);
            if(newCollectible.TryGetComponent<ScrollViewItem>(out ScrollViewItem item)) {
                // get title from collectible in collected and change it
                item.ChangeTitle("test title"); //how to get title from collectible?
            }
        }
    }

}
