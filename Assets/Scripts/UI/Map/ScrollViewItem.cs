using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ScrollViewItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject CollectedTitle;
    [SerializeField]
    private GameObject CollectedType;

    private GameObject collectible;
    private string title;
    private string type;
    private string body;
    private List<Sprite> Images;
    private string Question;
    private string Answer;
    private GameObject canvas;
    

    public void ChangeInventory(string title, string type, GameObject collected) {
        Debug.Log("changed inventory title to " + title);
        CollectedTitle.GetComponent<TextMeshProUGUI>().text = title;
        CollectedType.GetComponent<TextMeshProUGUI>().text = "Type: " + type;
        collectible = collected;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        title = collectible.GetComponent<Collectible>().GetTitle();
        Debug.Log("clicked inventory item " + title);

        type = collectible.GetComponent<Collectible>().GetType().Name;

        canvas = GameObject.Find("PanelsCanvas");

        GameObject.Find("Inventory").GetComponent<InventoryPanel>().setOpenedCollectible(true);
        collectible.GetComponent<Collectible>().OpenWindow(canvas);

        // expand panel based on type - node, text1, picture, video, sound
        // if (type == "Node") {

        // } else if (type == "Text1") {

        // } else if (type == "Picture") {

        // } else if (type == "Video") {

        // } else if (type == "Sound") {

        // }

    }
    
}
