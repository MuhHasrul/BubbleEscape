using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource audioClick;
    public GameObject muteIcon; // Ikon mute
    public GameObject unmuteIcon; // Ikon unmute // Gambar di tombol

    private bool isMuted = false;

    public void ToggleMute()
    {
        if (audioSource != null)
        {
            isMuted = !isMuted;
            if (isMuted) 
            {
                muteIcon.gameObject.SetActive(true);
                unmuteIcon.gameObject.SetActive(false);
            }
            else
            {
                muteIcon.gameObject.SetActive(false);
                unmuteIcon.gameObject.SetActive(true);
            }
            
            audioSource.mute = isMuted;
            
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    void Update(){
        if (Input.GetMouseButtonDown(0))
        {
            audioClick.Play();
        }
    }


}
