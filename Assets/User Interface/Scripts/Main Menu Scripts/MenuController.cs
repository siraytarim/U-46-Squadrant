using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Level To Load")]
    public string _newGameLevel;
    public string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialogue = null;


    public void NewGameDialogueYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogueYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialogue.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
