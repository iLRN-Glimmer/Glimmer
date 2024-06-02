using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    // Start is called before the first frame update
    private Material mat;

    public GameObject player;
    public float fadeDist = 3.0f;
    public float transparency = 0.0f;
    public float scalingFactor = 2.5f;

    public string Open;
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;

        Vector3 objectScale = transform.localScale;
        float tilingX = objectScale.x;
        float tilingY = objectScale.z;

        mat.mainTextureScale = new Vector2(tilingX, tilingY);
        player = GameObject.FindWithTag("Player");
        Color color = mat.GetColor("_Color");
        color.a = transparency;
        mat.SetColor("_Color", color);

        System.DateTime dateTime = System.DateTime.Parse(Open);
        if (System.DateTime.UtcNow > dateTime)
        {
            gameObject.SetActive(false);
        }
    }

    public IEnumerator ShowBoundary()
    {
        Collider playerCollider = player.GetComponent<Collider>();
        Collider objectCollider = GetComponent<Collider>();

        while(true)
        {
            Debug.Log("Changing transparency");
            float distanceToPlayer = Vector3.Distance(playerCollider.ClosestPoint(transform.position), objectCollider.ClosestPoint(player.transform.position));
            transparency = 1 - Mathf.Clamp01(distanceToPlayer / fadeDist); // Inverted
            Color color = mat.GetColor("_Color");
            color.a = transparency * scalingFactor;
            mat.SetColor("_Color", color);
            yield return null;
        }
    }

    // void Update()
    // {
    //     Collider playerCollider = player.GetComponent<Collider>();
    //     Collider objectCollider = GetComponent<Collider>();

    //     float distanceToPlayer = Vector3.Distance(playerCollider.ClosestPoint(transform.position), objectCollider.ClosestPoint(player.transform.position));
    //     transparency = 1 - Mathf.Clamp01(distanceToPlayer / fadeDist); // Inverted
    //     Color color = mat.GetColor("_Color");
    //     color.a = transparency;
    //     mat.SetColor("_Color", color);
    // }
}
