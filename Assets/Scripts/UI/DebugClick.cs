using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugClick : MonoBehaviour
{
     void Update()
    {
        // Check if the primary mouse button (left mouse button) is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Print a debug message to the console
            Debug.Log("Left mouse button clicked!");
        }

        // Check if the secondary mouse button (right mouse button) is clicked
        if (Input.GetMouseButtonDown(1))
        {
            // Print a debug message to the console
            Debug.Log("Right mouse button clicked!");
        }
    }
}
