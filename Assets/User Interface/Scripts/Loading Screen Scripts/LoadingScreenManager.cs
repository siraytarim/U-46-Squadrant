using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer loadingScreenVideoPlayer;

    void Update()
    {
        if (loadingScreenVideoPlayer.isPlaying)
        {
            Debug.Log("The cutscene video is currently playing.");
        }
        else
        {
            Debug.Log("The video is finished OR not currently playing.");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // a button can be added to control the flow of the scene loading.
        }
    }
}