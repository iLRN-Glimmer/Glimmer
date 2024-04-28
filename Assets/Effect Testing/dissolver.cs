using UnityEngine;

public class Dissolver : MonoBehaviour
{
    public GameObject player;
    private Material mat;
    public float dissolveDistance = 10.0f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Check if player is assigned and exists
        if (player != null)
        {
            Collider playerCollider = player.GetComponent<Collider>();
            Collider objectCollider = GetComponent<Collider>();

            if (playerCollider != null && objectCollider != null)
            {
                // Calculate the distance between player and object colliders
                float distanceToPlayer = Vector3.Distance(playerCollider.ClosestPoint(transform.position), objectCollider.ClosestPoint(player.transform.position));

                // Calculate the dissolve strength based on the distance
                float dissolveStrength = Mathf.Clamp01(distanceToPlayer / dissolveDistance); // Adjust 10.0f for the range
                dissolveStrength = Mathf.Clamp(dissolveStrength, 0.4f, 1.0f); // Clamp the value between 0 and 1 (0% and 100%
                // Set the dissolve strength in the shader
                mat.SetFloat("_DissolveStrength", dissolveStrength);

                // Report distance and strength to console
                Debug.Log("Distance to player: " + distanceToPlayer + ", Dissolve strength: " + dissolveStrength);
            }
            else
            {
                Debug.LogWarning("Player or object collider not found!");
            }
        }
        else
        {
            Debug.LogWarning("Player object not assigned or doesn't exist!");
        }
    }
}
