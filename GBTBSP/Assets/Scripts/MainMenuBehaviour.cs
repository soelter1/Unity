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
    public bool promptActive = false;

    public void startButtonClick()
    {
        if (!promptActive)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void DLCButtonCLick()
        {
            if (!promptActive)
            {
            }
    }


    public void ExitButtonClick()
    {
        if (!promptActive)
        {
            exitPrompt.gameObject.SetActive(true);
            promptActive = true;
        }
    }
}
