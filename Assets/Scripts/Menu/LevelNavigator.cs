using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelNavigator : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelMenu;


    private void Awake()
    {
        // reset menu components activity
        Cursor.visible = true;
        if (!mainMenu || !levelMenu) return;
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void EnterLevel(int chosenLevel)
    {
        SceneManager.LoadScene(chosenLevel);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LeadToStoryLevel()
    {
        SceneManager.LoadScene(5);
    }
}