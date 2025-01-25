using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour
{
    private string currentSceneName;
    public GameObject pausePanel;
    public GameObject playGamePanel;
    private bool isPaused = false;
    public AudioSource audioClick;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
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
        if (Input.GetMouseButtonDown(0))
        {
            audioClick.Play();
        }
        
    }

    private void Awake()
    {
        // Panggil GetActiveScene di sini
        currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current Scene Name: " + currentSceneName);

    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        playGamePanel.gameObject.SetActive(false);

    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        playGamePanel.gameObject.SetActive(true);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        // Me-reload scene dengan nama tersebut
        SceneManager.LoadScene(currentSceneName);
    }
    public void NextLevel()
    {
        if (currentSceneName == "Level 2")
        {
            SceneManager.LoadScene("Main Menu");
        } else {
            SceneManager.LoadScene("Level 2");
        }
        
       
    }
}
