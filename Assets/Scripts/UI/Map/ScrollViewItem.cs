using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ScrollViewItem : MonoBehaviour
{
    [SerializeField]
    private GameObject CollectedTitle;
    [SerializeField]
    private GameObject CollectedType;
    

    public void ChangeInventory(string title, string type) {
        Debug.Log("changed inventory title to " + title);
        CollectedTitle.GetComponent<TextMeshProUGUI>().text = title;
        CollectedType.GetComponent<TextMeshProUGUI>().text = "Type: " + type;
    }
    
}
