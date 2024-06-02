using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.Collections;

public class StartWebGLVideoPlayer : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private string videoFileName;
    [SerializeField]
    private GameObject[] elementsToActivate;

    void Start()
    {
        // Initially deactivate other elements
        foreach (GameObject element in elementsToActivate)
        {
            element.SetActive(false);
        }
        
        // Start preparing the video
        StartCoroutine(PrepareAndPlayVideo());
    }

    IEnumerator PrepareAndPlayVideo()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);

#if UNITY_WEBGL
        UnityWebRequest request = UnityWebRequest.Get(videoPath);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            videoPlayer.url = request.uri.AbsoluteUri;
            videoPlayer.Prepare();

            // Wait until the video is prepared
            while (!videoPlayer.isPrepared)
            {
                yield return null;
            }

            // Activate other elements after the video is prepared
            foreach (GameObject element in elementsToActivate)
            {
                element.SetActive(true);
            }

            // Play the video
            videoPlayer.Play();
        }
#else
        videoPlayer.url = videoPath;
        videoPlayer.Prepare();

        // Wait until the video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // Activate other elements after the video is prepared
        foreach (GameObject element in elementsToActivate)
        {
            element.SetActive(true);
        }

        // Play the video
        videoPlayer.Play();
#endif
    }
}
