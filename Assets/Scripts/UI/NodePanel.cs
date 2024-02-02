using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        this.transform.Find("Question").gameObject.SetActive(false);
        transform.Find("NodeDescription").gameObject.SetActive(true);
    }
}
