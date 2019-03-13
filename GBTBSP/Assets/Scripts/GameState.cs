using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public Cursor cursor;
    public AudioSource buttonpress;
    public AudioSource Music;
    public GameObject[] moveAbleObjects;

    public GameObject turnPopUp;
    public GameObject GameOverPopUp;
    public GameObject MenuPanel;
    public GameObject HelpPanel;

    public Text winPlaya;
    public Text TurnText;
    public Text PlayerText;

    public int gameTurn = 1;
    public int playerTurn = 1;

    private void Update()
    {
        if (Input.GetKeyDown("t")) turnClick();
    }

    private void Start()
    {
        PopUpControl();
        Invoke("KillPopUp", 2);
        moveAbleObjects = GameObject.FindGameObjectsWithTag("MoveAbleObject");
    }

    public void gameOver(int player)
    {
        Debug.Log("Game Over");
        winPlaya.text = player+"";
        GameOverPopUp.SetActive(true);
        cursor.gameObject.SetActive(false);
    }

    public void menuClick()
    {
        buttonpress.Play();
        if (!MenuPanel.activeSelf) MenuPanel.SetActive(true);
        else MenuPanel.SetActive(false);
    }

    public void helpClick()
    {
        buttonpress.Play();
        if (!HelpPanel.activeSelf) HelpPanel.SetActive(true);
        else HelpPanel.SetActive(false);
    }

    public void turnClick()
    {
        buttonpress.Play();
        cursor.controlSwitch();
        moveAbleObjects = GameObject.FindGameObjectsWithTag("MoveAbleObject");
        if(cursor.selectedTarget != null)cursor.deselectTarget();
        foreach(GameObject mOb in moveAbleObjects)
        {
            mOb.GetComponent<MoveAbleObject>().hasMoved = false;
            mOb.GetComponent<MoveAbleObject>().hasAttacked = false;

            if(mOb.name != "BlenderKing")
            {
                mOb.GetComponent<NonLethalProjectileBehaviourScript>().enabled = false;
                mOb.GetComponent<LethalProjectileBehaviourScript>().enabled = false;
            }
        }

        if (playerTurn == 1)
        {
            playerTurn = 2;
            cursor.gameObject.transform.position = new Vector3(0, cursor.gameObject.transform.position.y, 110);
        }
        else
        {
            cursor.gameObject.transform.position = new Vector3(0, cursor.gameObject.transform.position.y, 0);
            gameTurn += 1;
            playerTurn = 1;
        }
        PopUpControl();
        Invoke("KillPopUp", 2);
    }

    public void quitButtonClick()
    {
        buttonpress.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void restartButtonClick()
    {
        buttonpress.Play();
        SceneManager.LoadScene("SampleGameScene");
    }

    public void musicToggle()
    {
        if (Music.isPlaying) Music.Pause();
        else Music.Play();
    }
    
    void PopUpControl()
    {
        TurnText.text = "Turn " + gameTurn;
        PlayerText.text = "Player " + playerTurn;
        turnPopUp.SetActive(true);
    }

    void KillPopUp()
    {
        turnPopUp.SetActive(false);
    }
}
