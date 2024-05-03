using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolver : MonoBehaviour
{
    public float dissolveStrength;
    public float dissolveDuration = 2;
    public IEnumerator DissolveIn()
    {
        Debug.Log("Starting to Dissolve");
        float t = 0;
        Material mat = GetComponent<Renderer>().material;
        float startVal = mat.GetFloat("_DissolveStrength");
        while (t < dissolveDuration)
        {
            t += Time.deltaTime;
            dissolveStrength = Mathf.Clamp(Mathf.Lerp(startVal, 0.4f, t / dissolveDuration), 0.4f, 0.75f);
            mat.SetFloat("_DissolveStrength", dissolveStrength);
            yield return null;
        }
    }

    public IEnumerator DissolveOut()
    {
        Debug.Log("Starting to Dissolve");
        float t = 0;
        Material mat = GetComponent<Renderer>().material;
        while (t < dissolveDuration)
        {
            t += Time.deltaTime;
            dissolveStrength = Mathf.Clamp(Mathf.Lerp(0.4f, 0.75f, t / dissolveDuration), 0.4f, 0.75f);
            mat.SetFloat("_DissolveStrength", dissolveStrength);
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