using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPrompt : MonoBehaviour
{
    public Button finalExitButton;
    public Button cancelButton;

    public MainMenuBehaviour main;
    public AudioSource klick;

    public void finalExitButtonClick()
    {
        klick.Play();
        Application.Quit();
    }

    public void cancelButtonClick()
    {
        klick.Play();
        this.gameObject.SetActive(false);
        main.promptActive = false;
    }

    public void BuyButton()
    {
        klick.Play();
        Application.OpenURL("http://paypal.com/signin");
    }
}
