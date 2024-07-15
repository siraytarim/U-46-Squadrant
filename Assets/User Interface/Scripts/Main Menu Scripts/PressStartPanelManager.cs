using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressStartPanelManager : MonoBehaviour
{
    // Enum to represent the build type
    public enum BuildType
    {
        Windows,
        Xbox,
        PlayStation,
        NintendoSwitch
    }

    // Reference to the FirstSelectedManager script component
    private FirstSelectedManager firstSelectedManager;

    [Header("Build Related Settings")]
    [SerializeField] private BuildType buildType;
    [SerializeField] private GameObject pressStartWindows;
    [SerializeField] private GameObject pressStartXbox;
    [SerializeField] private GameObject pressStartPlaystation;
    [SerializeField] private GameObject pressStartSwitch;

    // Serialized fields for background components
    [Header("Background Components")]
    [SerializeField] private Image backgroundStartBlack;
    [SerializeField] private GameObject backgroundStart;
    [SerializeField] private GameObject backgroundMain;

    // Serialized fields for UI panels
    [Header("UI Panels")]
    [SerializeField] private GameObject pressStartPanel;
    [SerializeField] private GameObject mainMenuPanel;

    // Dictionary to map build types to game objects
    private Dictionary<BuildType, GameObject> buildTypeToGameObject;

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    
        // Get the FirstSelectedManager script component
        firstSelectedManager = GetComponent<FirstSelectedManager>();
    
        // Initialize the dictionary
        buildTypeToGameObject = new Dictionary<BuildType, GameObject>
        {
            {BuildType.Windows, pressStartWindows},
            {BuildType.Xbox, pressStartXbox},
            {BuildType.PlayStation, pressStartPlaystation},
            {BuildType.NintendoSwitch, pressStartSwitch}
        };
    
        // Set the initial state of the UI
        pressStartPanel.SetActive(true);
        backgroundStart.SetActive(true);
        ChooseStartButton();
    
        // Start the fade out the black screen first
        StartCoroutine(FadeOutBlackBackground(backgroundStartBlack, 2f));
    }

    void Update()
    {
        //KeepButtonSelected();
    }

    //private void KeepButtonSelected()
    //{
    //    if (EventSystem.current.currentSelectedGameObject == null)
    //    {
    //        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    //    }
    //}

    // Method to choose the start button based on the build type
    private void ChooseStartButton()
    {
        if (buildTypeToGameObject.TryGetValue(buildType, out var gameObject))
        {
            gameObject.SetActive(true);
            firstSelectedManager.FirstSelectedIn_PressStart(gameObject);
        }
    }

    // Coroutine to fade out the black background
    IEnumerator FadeOutBlackBackground(Image image, float duration)
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(FadeOut(image, duration));
        image.enabled = false;
    }

    // Method to start the main menu
    public void StartMainMenu()
    {
        mainMenuPanel.SetActive(true);
        pressStartPanel.SetActive(false);
        StartCoroutine(BackgroundTransitionStartToNormal());
    }

    // Coroutine to transition the background from start to normal
    IEnumerator BackgroundTransitionStartToNormal()
    {
        backgroundMain.SetActive(true);
        RawImage backgroundStartRawImage = backgroundStart.GetComponent<RawImage>();
        yield return StartCoroutine(FadeOut(backgroundStartRawImage, 2f));
        backgroundStart.SetActive(false);
    }

    // A general Coroutine method to fade out an image
    IEnumerator FadeOut(Graphic image, float duration)
    {
        float elapsedTime = 0;
        Color initialColor = image.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        while (elapsedTime < duration)
        {
            // Dont use Color.Lerp! It is not working properly with alpha values, I dont know why.
            float newAlpha = Mathf.Lerp(initialColor.a, targetColor.a, elapsedTime / duration);
            image.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}