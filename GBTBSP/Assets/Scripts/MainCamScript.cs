using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamScript : MonoBehaviour
{
    public GameState gameState;
    public Transform cursor;

    public int posCount = 1;
    public Vector3 p1Pkt1;
    public Vector3 p1Rot1;
    public Vector3 p1Pkt2;
    public Vector3 p1Rot2;
    public Vector3 p2Pkt1;
    public Vector3 p2Rot1;
    public Vector3 p2Pkt2;
    public Vector3 p2Rot2;

    Vector3 Rot3 = new Vector3(90, 0, 0);


    private void Update()
    {
        if(Input.GetKeyUp("c")){
            if (posCount < 4)
            { 
                posCount += 1;
            }
            else if (posCount == 3)
            {
                posCount = 1;
            }
        }

        if (posCount == 1 && gameState.playerTurn == 1)
        {
            transform.position = p1Pkt1;
            transform.rotation = Quaternion.Euler(p1Rot1);
        }
        if (posCount == 2 && gameState.playerTurn == 1)
        {
            transform.position = p1Pkt2;
            transform.rotation = Quaternion.Euler(p1Rot2);
        }
        if (posCount == 1 && gameState.playerTurn == 2)
        {
            transform.position = p2Pkt1;
            transform.rotation = Quaternion.Euler(p2Rot1);
        }
        if (posCount == 2 && gameState.playerTurn == 2)
        {
            transform.position = p2Pkt2;
            transform.rotation = Quaternion.Euler(p2Rot2);
        }
        
        if (posCount == 3 && gameState.playerTurn == 1)
        {
            transform.position = cursor.position + p1Pkt1;
            transform.rotation = Quaternion.Euler(p1Rot1);
        }
        if (posCount == 3 && gameState.playerTurn == 2)
        {
            transform.position = cursor.position + new Vector3(p1Pkt1.x, 40, -p1Pkt1.z);
            transform.rotation = Quaternion.Euler(p2Rot1);
        }
        if(posCount == 4)
        {
            transform.position = cursor.position + new Vector3(0, 50, 0);
            transform.rotation = Quaternion.Euler(Rot3);
        }
    }
}
