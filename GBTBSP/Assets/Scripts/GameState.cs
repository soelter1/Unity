using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Cursor cursor;

    public GameObject turnPopUp;
    public Text TurnText;
    public Text PlayerText;

    public int gameTurn = 1;
    public int playerTurn = 1;

    

    public void turnClick()
    {
        //cursor.disselectTarget;
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
