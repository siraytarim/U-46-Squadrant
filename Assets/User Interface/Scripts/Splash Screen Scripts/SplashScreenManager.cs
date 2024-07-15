using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// The SplashScreenManagerAlt class is responsible for managing the splash screen sequence in a Unity game.
/// It controls the display of multiple splash groups (each represented by a GameObject), which are shown in sequence with fade-in and fade-out effects.
/// Each splash group can contain multiple Image and TextMeshProUGUI components, and the alpha value of these components is manipulated to create the fade effects.
/// The sequence of splash groups is controlled by a coroutine, which allows for asynchronous waiting between the display of each group.
/// After all splash groups have been displayed, the script automatically loads the next scene in the build order which is planned to be the main menu.
/// </summary>
public class SplashScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject[] splashGroups; // Array of GameObjects representing splash groups
    [SerializeField] private AudioSource soundTrackAudioSource; // AudioSource for the soundtrack
    [SerializeField] private float waitDuration = 1.0f;
    [SerializeField] private float fadeInDuration = 1.0f;
    [SerializeField] private float visibleDuration = 1.0f;
    [SerializeField] private float fadeOutDuration = 1.0f;

    /// <summary>
    /// Start is called before the first frame update.
    /// It initializes the splashGroups by setting them inactive and their alpha to zero.
    /// It also starts the SplashSequence coroutine.
    /// </summary>
    void Start()
    {
        foreach (var splashGroup in splashGroups)
        {
            splashGroup.SetActive(false);
            SetAlphaToZero(splashGroup);
        }

        StartCoroutine(SplashSequence());
    }

    /// <summary>
    /// Sets the alpha of all Image and TextMeshProUGUI components in the given GameObject to zero.
    /// This is used to make the splash group invisible at the start.
    /// </summary>
    void SetAlphaToZero(GameObject splashGroup)
    {
        SetAlphaInChildren<Image>(splashGroup, 0);
        SetAlphaInChildren<TextMeshProUGUI>(splashGroup, 0);
    }

    /// <summary>
    /// Sets the alpha of all components of type Thing in the given GameObject to the specified alpha value.
    /// This is used to control the visibility of the splash group.
    /// </summary>
    void SetAlphaInChildren<Thing>(GameObject splashGroup, float alpha) where Thing : Graphic
    {
        foreach (Thing component in splashGroup.GetComponentsInChildren<Thing>())
        {
            Color color = component.color;
            color.a = alpha;
            component.color = color;
        }
    }

    /// <summary>
    /// Coroutine that sequentially displays each splashGroup with a fade in and fade out effect.
    /// After all splashGroups have been displayed, it loads the next scene.
    /// </summary>
    IEnumerator SplashSequence()
    {
        foreach (var splashGroup in splashGroups)
        {
            yield return SplashSequenceByGroups(splashGroup);
        }
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Coroutine that displays a single splashGroup with a fade in and fade out effect.
    /// This is used to control the sequence of displaying the splash groups.
    /// </summary>
    IEnumerator SplashSequenceByGroups(GameObject splashGroup)
    {
        yield return new WaitForSeconds(waitDuration);
        splashGroup.SetActive(true);
        if (splashGroup == splashGroups[splashGroups.Length - 1]) StartCoroutine(FadeOutAudio(fadeInDuration + visibleDuration));
        yield return StartCoroutine(FadeEffect(splashGroup, 0, 1, fadeInDuration));
        yield return new WaitForSeconds(visibleDuration);
        yield return StartCoroutine(FadeEffect(splashGroup, 1, 0, fadeOutDuration));
    
        splashGroup.SetActive(false);
    }

    /// <summary>
    /// Coroutine that applies a fade effect to a splashGroup over a specified duration.
    /// The fade effect is applied to all Image and TextMeshProUGUI components in the splashGroup.
    /// This is used to create the fade-in and fade-out effects.
    /// </summary>
    IEnumerator FadeEffect(GameObject splashGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            SetAlphaInChildren<Image>(splashGroup, Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration));
            SetAlphaInChildren<TextMeshProUGUI>(splashGroup, Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// Coroutine that fades out the audio over a specified duration.
    /// This is used to fade out the soundtrack when the last splash group is displayed.
    /// </summary>
    IEnumerator FadeOutAudio(float duration)
    {
        float startVolume = soundTrackAudioSource.volume;
        float elapsedTime = 0;
    
        while (soundTrackAudioSource.volume > 0)
        {
            elapsedTime += Time.deltaTime;
            soundTrackAudioSource.volume = Mathf.Lerp(startVolume, 0, elapsedTime / duration);
    
            yield return null;
        }
    
        soundTrackAudioSource.Stop();
    }
}