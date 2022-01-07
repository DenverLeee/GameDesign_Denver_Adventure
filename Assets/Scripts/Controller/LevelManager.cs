using System;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    private GameObject player;
    private GameObject pauseMenu;
    private bool isPaused;
    public bool canMove;

    private void Awake()
    {
        player = GameObject.Find("Player");
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            InvertPauseState();
        }
    }

    public void InvertPauseState()
    {
        
        pauseMenu.SetActive(!isPaused);
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
        isPaused = !isPaused;
    }

    public void PauseGame(int timeScale = 0)
    {
        Time.timeScale = timeScale;
        InvertPlayerStates();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        InvertPlayerStates();
    }

    public void ResetLevel()
    {
        isPaused = false;
        Time.timeScale = 1;
        ResetPlayerStates();
    }

    public void ResetPlayerStates()
    {
        canMove = true;
    }

    public void InvertPlayerStates()
    {
        canMove = !canMove;
    }
}