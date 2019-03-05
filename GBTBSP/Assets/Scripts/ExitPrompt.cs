using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPrompt : MonoBehaviour
{
    public Button finalExitButton;
    public Button cancelButton;

    public MainMenuBehaviour main;

    public void finalExitButtonClick()
    {
        Application.Quit();
    }

    public void cancelButtonClick()
    {
        this.gameObject.SetActive(false);
        main.promptActive = false;
    }
}
