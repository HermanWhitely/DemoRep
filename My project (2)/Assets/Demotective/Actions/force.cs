using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SimpleVideoLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "GoodStart";

    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Видео завершено. Переход к сцене: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
