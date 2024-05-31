using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.Collections;

public class WebGLVideoPlayer : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private string videoFileName = "GLIMMERstartslow1.mp4";

    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
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

        // Play the video
        videoPlayer.Play();
#endif
    }
}
