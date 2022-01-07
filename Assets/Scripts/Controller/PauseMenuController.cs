using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }
    }

    public void ContinueGame()
    {
        levelManager.InvertPauseState();
    }

    // Back to MainMenu
    public void QuitGame()
    {
        levelManager.ResetLevel();
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }
}