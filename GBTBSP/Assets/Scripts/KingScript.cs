using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingScript : MonoBehaviour
{
    public GameState gamestate;

    public void theKingIsDeadLongLiveTheKing(int player)
    {
        gamestate.gameOver(player);
    }
}
