using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDeactivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Transform Go = this.gameObject.transform.GetChild(i);
            Go.gameObject.SetActive(true);
            Go.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
