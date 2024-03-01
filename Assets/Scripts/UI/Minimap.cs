using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    void LateUpdate ()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        // add rotation to the map
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);

    }
}
