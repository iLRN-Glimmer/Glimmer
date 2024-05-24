using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CanvasDeactivate : MonoBehaviour
{

    [SerializeField]
    private GameObject minimap;

    [SerializeField]
    private GameObject welcome;

    void Awake()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Transform Go = this.gameObject.transform.GetChild(i);
            Go.gameObject.SetActive(true);
            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Transform Go = this.gameObject.transform.GetChild(i);
            Go.gameObject.SetActive(true);
            if (Go.name != "ReticlePanel")
            {
                Go.gameObject.SetActive(false);
            }
        }

        if (minimap != null)
        {
            minimap.SetActive(true);
        }

        welcome.SetActive(true);

        // unlock cursor for beginning
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
        // GameObject.Find("controller/PlayerCapsule").GetComponent<FirstPersonController>().SetFreeze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
