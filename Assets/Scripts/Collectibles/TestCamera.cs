using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestCamera : MonoBehaviour
{


    //public GameObject Player;
    //private PlayerMovement script;
    //public Transform orientation;
    [SerializeField]
    private string selectableTag = "Selectable";

    [SerializeField]
    private Material highlightMaterial;

    [SerializeField]
    private Material defaultMaterial;

    public float mouseSensitivity = 3f;
    float cameraVerticalRotation = 0f;
    float cameraHorizontalRotation = 0f;

    private GameObject canvas;

    private Transform _selection;

    bool freeze = false;




    bool lockedCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canvas = GameObject.Find("PanelsCanvas");

    }

    // Update is called once per frame
    void Update()
    {

        





        
        if(!freeze){
            
            if (_selection != null)
            {
                var selectionRenderer = _selection.GetComponent<Renderer>();
                selectionRenderer.material = defaultMaterial;
                _selection = null;
            }
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            // Set the length of the ray (adjust as needed)
            float rayLength = 10f;

            // Draw the ray
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                    }
                    _selection = selection;
                }

            }
        
        

            if (Input.GetMouseButtonDown(0) && _selection){
                _selection.gameObject.GetComponent<Collectible>().OpenWindow(canvas);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
                freeze = true;
            }
        }
    }

    public void Unpause(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        freeze = false;
    }
}
