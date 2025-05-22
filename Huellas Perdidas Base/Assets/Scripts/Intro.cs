using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName; // Nombre de la escena a cargar

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("Menu Principal");
    }
}