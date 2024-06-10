using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        CultureInfo provider = CultureInfo.InvariantCulture;
        try
        {
            string[] formats = { "yyyy-MM-dd HH:mm:ss", "yyyy-M-d H:m:s" };
            System.DateTime dateTime;

            if (System.DateTime.TryParseExact(Open, formats, null, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                if (System.DateTime.UtcNow > dateTime)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.LogError($"Failed to parse date: {Open}. The format should be either 'yyyy-MM-dd HH:mm:ss' or 'yyyy-M-d H:m:s'.");
            }
        }
        catch (System.FormatException e)
        {
            Debug.LogError($"Failed to parse date: {Open}. Error: {e.Message}");
        }
        //System.DateTime dateTime = System.DateTime.ParseExact(Open, "yyyy-MM-dd HH:mm:ss", null);
        //Debug.Log(System.DateTime.UtcNow);
        //if (System.DateTime.UtcNow > dateTime)
        //{
        //    gameObject.SetActive(false);
        //}
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

    public IEnumerator HideBoundary()
    {
        Color color = mat.GetColor("_Color");
        color.a = 0f;
        mat.SetColor("_Color", color);
        yield return null;
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
