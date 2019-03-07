using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cursor : MonoBehaviour
{
    public GameState gameState;
    public MoveAbleObject selectedTarget;
    public MoveAbleObject onObject;
    public SelectedUI selectedUI;
    public GridBehaviourScript grid;

    public int gridsizeX;
    public int gridsizeZ;

    bool targetSelected = false;

    public bool onTarget = false;
    public bool blocked = false;

    private void selectTarget()
    {
        selectedTarget = onObject;
        targetSelected = true;
        selectedUI.UpdateTo(selectedTarget);
    }

    public void deselectTarget()
    {
        // Moved Stuff
        if (selectedTarget != null)
        {
            grid.ShowMovementRange(selectedTarget, false);
            grid.ShowAttackRange(selectedTarget, false);
        }
        //
        selectedTarget = null;
        targetSelected = false;
        selectedUI.UpdateToNone();
    }

    public bool IsReachable(Vector3 destination, Vector3[] reachable)
    {

        if (Array.Exists<Vector3>(reachable, element => element == destination)) return true;
        else return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("w") && !(transform.position.z == (gridsizeZ * 10)))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(0, 0, 10f)));
        }
        if (Input.GetKeyDown("s") && !(transform.position.z == 0f))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(0, 0, -10f)));
        }
        if (Input.GetKeyDown("a") && !(transform.position.x == 0f))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(-10f, 0, 0)));
        }
        if (Input.GetKeyDown("d") && !(transform.position.x == (gridsizeX * 10f)))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(10f, 0, 0)));
        }
        if (Input.GetKeyDown("space") && targetSelected && !(blocked || onTarget))
        {
            if (IsReachable(transform.position, grid.movementRangeArray))
            {
                selectedTarget.Move(transform.position.x, transform.position.z);

                selectTarget();
                /* Moved to Disselect
                grid.ShowMovementRange(selectedTarget, false);
                grid.ShowAttackRange(selectedTarget, false);
                */
                deselectTarget();
            }
            else
            {
                Debug.Log(transform.position + " is not reachable.");
                selectedTarget.Move(transform.position.x, transform.position.z);
            }
        }
        if (Input.GetKeyDown("f") && onObject.player == gameState.playerTurn)
        {
            if (onTarget)
            {
                if (!onObject.hasMoved && !onObject.hasAttacked)
                {
                    selectTarget();
                    grid.ShowMovementRange(selectedTarget, true);
                    grid.ShowAttackRange(selectedTarget, true);
                }
                else if(onObject.hasMoved && !onObject.hasAttacked)
                {
                    selectTarget();
                    grid.ShowAttackRange(selectedTarget, true);
                }
            }
            else
            {
                selectTarget();
                grid.ShowMovementRange(selectedTarget, false);
                grid.ShowAttackRange(selectedTarget, false);
                deselectTarget();
            }
        }
        if (Input.GetKeyDown("e") && onTarget && (onObject.player!=selectedTarget.player) )
        {
            selectedTarget.Attack(onObject);
            grid.ShowMovementRange(selectedTarget, false);
            grid.ShowAttackRange(selectedTarget, false);
            deselectTarget();
        }

    }

}