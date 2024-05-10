using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ScrollViewItem : MonoBehaviour
{
    [SerializeField]
    private GameObject CollectedTitle;

    public void ChangeTitle(string title) {
        Debug.Log("changed inventory title to " + title);
        CollectedTitle.GetComponent<TextMeshProUGUI>().text = title;
    }
    
}
