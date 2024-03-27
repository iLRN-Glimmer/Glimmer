using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    private void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, 80, Player.transform.position.z);
    }
}
