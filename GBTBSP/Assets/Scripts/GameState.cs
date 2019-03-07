using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Cursor cursor;
    public GameObject[] moveAbleObjects;

    public GameObject turnPopUp;
    public GameObject GameOverPopUp;
    public Text winPlaya;
    public Text TurnText;
    public Text PlayerText;

    public int gameTurn = 1;
    public int playerTurn = 1;

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

    }

    public void helpClick()
    {

    }

    public void turnClick()
    {
        moveAbleObjects = GameObject.FindGameObjectsWithTag("MoveAbleObject");
        if(cursor.selectedTarget != null)cursor.deselectTarget();
        foreach(GameObject mOb in moveAbleObjects)
        {
            mOb.GetComponent<MoveAbleObject>().hasMoved = false;
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
