using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelectedManager : MonoBehaviour
{
    EventSystem eventSystem;

    [Header("First Selected Settings for Menu Panels")]
    [SerializeField] private GameObject mainMenuFirstSelection;
    [SerializeField] private GameObject loadMenuFirstSelection;
    [SerializeField] private GameObject optionsMenuFirstSelection;
    [SerializeField] private GameObject creditsMenuFirstSelection;

    [Header("First Selected Settings for Pop-up Panels")]
    [SerializeField] private GameObject newGamePopupFirstSelection;
    [SerializeField] private GameObject quitGamePopupFirstSelection;

    [Header("First Selected Settings for Going Back to Main Menu Panel")]
    [SerializeField] private GameObject newGameToMainMenuFirstSelection;
    [SerializeField] private GameObject quitToMainMenuFirstSelection;
    [SerializeField] private GameObject loadToMainMenuFirstSelection;
    [SerializeField] private GameObject optionsToMainMenuFirstSelection;
    [SerializeField] private GameObject creditsToMainMenuFirstSelection;
    
    void OnEnable()
    {
        eventSystem = EventSystem.current;
    }
    
    private void AssignFirstSelected(GameObject gameObject)
    {
        eventSystem.SetSelectedGameObject(gameObject);
    }

    // Splash Screen
    public void FirstSelectedIn_PressStart(GameObject gameObject)
    {
        AssignFirstSelected(gameObject);
    }
    
    public void FirstSelectedIn_MainMenu()
    {
        AssignFirstSelected(mainMenuFirstSelection);
    }

    // Main Menu
    public void FirstSelectedIn_LoadGameMenu()
    {
        AssignFirstSelected(loadMenuFirstSelection);
    }

    public void FirstSelectedIn_OptionsMenu()
    {
        AssignFirstSelected(optionsMenuFirstSelection);
    }

    public void FirstSelectedIn_CreditsMenu()
    {
        AssignFirstSelected(creditsMenuFirstSelection);
    }

    // Main Menu Popups
    public void FirstSelectedIn_NewGamePopup()
    {
        AssignFirstSelected(newGamePopupFirstSelection);
    }
    public void FirstSelectedIn_QuitPopup()
    {
        AssignFirstSelected(quitGamePopupFirstSelection);
    }

    // Going Back to Main Menu
    public void FirstSelectedIn_LoadGame2MainMenu()
    {
        AssignFirstSelected(loadToMainMenuFirstSelection);
    }

    public void FirstSelectedIn_NewGame2MainMenu()
    {
        AssignFirstSelected(newGameToMainMenuFirstSelection);
    }

    public void FirstSelectedIn_Options2MainMenu()
    {
        AssignFirstSelected(optionsToMainMenuFirstSelection);
    }

    public void FirstSelectedIn_Credits2MainMenu()
    {
        AssignFirstSelected(creditsToMainMenuFirstSelection);
    }
    public void FirstSelectedIn_Quit2MainMenu()
    {
        AssignFirstSelected(quitToMainMenuFirstSelection);
    }
}