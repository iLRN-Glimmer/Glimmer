using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolver : MonoBehaviour
{
    public float dissolveStrength;
    public float dissolveDuration = 2;
    public GameObject player;
    public float dissolveDistance = 10.0f;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    public IEnumerator ShowBoundary()
    {
        //Debug.Log("Starting to Dissolve");
        //float t = 0;
        //Material mat = GetComponent<Renderer>().material;
        //float startVal = mat.GetFloat("_DissolveStrength");
        //while (t < dissolveDuration)
        //{
        //    t += Time.deltaTime;
        //    dissolveStrength = Mathf.Clamp(Mathf.Lerp(startVal, 0.4f, t / dissolveDuration), 0.4f, 0.75f);
        //    mat.SetFloat("_DissolveStrength", dissolveStrength);
        //    yield return null;
        //}

        Collider playerCollider = player.GetComponent<Collider>();
        Collider objectCollider = GetComponent<Collider>();

        while (true)
        {
            // Calculate the distance between player and object colliders
            float distanceToPlayer = Vector3.Distance(playerCollider.ClosestPoint(transform.position), objectCollider.ClosestPoint(player.transform.position));

            // Calculate the dissolve strength based on the distance
            float dissolveStrength = Mathf.Clamp01(distanceToPlayer / dissolveDistance); // Adjust 10.0f for the range
            dissolveStrength = Mathf.Clamp(dissolveStrength, 0.4f, 0.75f); // Clamp the value between 0 and 1 (0% and 100%
            // Set the dissolve strength in the shader
            mat.SetFloat("_DissolveStrength", dissolveStrength);
            Debug.Log("Changing Dessilve Strength to " + dissolveStrength);
            yield return null;
        }
        
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(Dissolve());
    //    }
    //}
}