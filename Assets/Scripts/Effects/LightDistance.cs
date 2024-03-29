using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBasedLightIntensity : MonoBehaviour
{
    public Transform targetObject; // The object to measure distance to
    public Light targetLight; // The light whose intensity will be adjusted
    public float minDistance = 1f; // The distance at which the light intensity reaches its maximum value
    public float maxDistance = 10f; // The distance at which the light intensity reaches its minimum value
    public float minIntensity = 0.1f; // The minimum intensity the light can have
    public float maxIntensity = 1f; // The maximum intensity the light can have
    public float intensityDecreaseRate = 1f; // Rate at which the light intensity decreases

    void Update()
    {
        if (targetObject == null || targetLight == null)
        {
            Debug.LogError("Target object or light is not assigned.");
            return;
        }

        float distance = Vector3.Distance(transform.position, targetObject.position);
        Debug.Log("Distance: " + distance);
        // Clamp the distance within the specified range
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Calculate the normalized distance between min and max distances
        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);
        
         float decreaseRate = Mathf.Pow(distance / maxDistance, 2);

        // Interpolate between min and max intensity based on distance and decrease rate
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, t) - decreaseRate * Time.deltaTime;

        // Set the lights intensity
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            light.intensity = intensity;
        }
    }
}
