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
        //script = Player.GetComponent<PlayerMovement>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canvas = GameObject.Find("PanelsCanvas");

    }

    // Update is called once per frame
    void Update()
    {




        
        if(!freeze){
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            cameraHorizontalRotation += inputX;
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            transform.rotation = Quaternion.Euler(cameraVerticalRotation, cameraHorizontalRotation, 0);
            //transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
            //orientation.rotation = Quaternion.Euler(cameraVerticalRotation, cameraHorizontalRotation, 0);
            if (_selection != null)
            {
                var selectionRenderer = _selection.GetComponent<Renderer>();
                selectionRenderer.material = defaultMaterial;
                _selection = null;
            }
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
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
        }
        

        if (Input.GetMouseButtonDown(0) && _selection){
            _selection.gameObject.GetComponent<Collectible>().OpenWindow(canvas);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            freeze = true;
        }
    }
}
