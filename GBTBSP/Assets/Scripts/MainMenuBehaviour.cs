using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public Button startButton;
    public Button DLCButton;
    public Button exitButton;

    public ExitPrompt exitPrompt;
    public ExitPrompt DLC;
    public bool promptActive = false;

    public AudioSource klick;
    public AudioSource offGrid;

    public void startButtonClick()
    {
        if (!promptActive)
        {
            offGrid.Play();
            Invoke("startGame", 1.8f);
        }
    }

    public void DLCButtonCLick()
        {
            if (!promptActive)
            {
            klick.Play();
            DLC.gameObject.SetActive(true);
            promptActive = true;
            }
    }

    public void ExitButtonClick()
    {
        if (!promptActive)
        {
            klick.Play();
            exitPrompt.gameObject.SetActive(true);
            promptActive = true;
        }
    }

    void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
