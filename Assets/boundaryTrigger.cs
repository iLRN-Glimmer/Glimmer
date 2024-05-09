using Unity.VisualScripting;
using UnityEngine;

public class boundaryTrigger : MonoBehaviour
{
    public GameObject objectToDissolve;
    private Coroutine boundaryCoroutine;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with Trigger");
        boundaryCoroutine = StartCoroutine(objectToDissolve.GetComponent<GridController>().ShowBoundary());
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited Trigger");
        StopCoroutine(boundaryCoroutine);
    }
}
