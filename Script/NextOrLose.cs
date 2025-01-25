using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextOrLose : MonoBehaviour
{
    string currentSceneName = SceneManager.GetActiveScene().name;
    public void NextLevel()
    {
       SceneManager.LoadScene("Level 2");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        // Me-reload scene dengan nama tersebut
        SceneManager.LoadScene(currentSceneName);
    }
    
}
