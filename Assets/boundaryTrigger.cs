using Unity.VisualScripting;
using UnityEngine;

public class boundaryTrigger : MonoBehaviour
{
    public GameObject objectToDissolve;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with Trigger");
        StartCoroutine(objectToDissolve.GetComponent<dissolver>().DissolveIn());
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collided with Trigger");
        StartCoroutine(objectToDissolve.GetComponent<dissolver>().DissolveOut());
    }
}
