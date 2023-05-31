using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI game object
    public AudioClip clickSound;
    public AudioSource buttonClick;

    private bool isPaused = false; // Flag to track if the game is paused

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        buttonClick.PlayOneShot(clickSound);
        Application.Quit();
        Debug.Log("Quitting the game...");
    }

    public void PlayClickSound()
    {
        buttonClick.PlayOneShot(clickSound);
    }
}
