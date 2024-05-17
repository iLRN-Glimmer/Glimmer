using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDeactivate : MonoBehaviour
{

    [SerializeField]
    private GameObject minimap;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
