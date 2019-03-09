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

    public String[] controls = { "w", "a", "s", "d", "space", "f"}; //Up, Left, Down, Right, Action, Select

    public int gridsizeX;
    public int gridsizeZ;

    bool targetSelected = false;

    public bool onTarget = false;
    public bool blocked = false;

    public void controlSwitch()
    {
        String temp = controls[0];
        controls[0] = controls[2]; controls[2] = temp;
        temp = controls[1];
        controls[1] = controls[3]; controls[3] = temp;
    }

    private void selectTarget()
    {
        if (selectedTarget != null) deselectTarget();
        selectedTarget = onObject;
        targetSelected = true;
        selectedUI.UpdateTo(selectedTarget);
        if (!onObject.hasMoved && !onObject.hasAttacked)
        {
            grid.ShowMovementRange(selectedTarget, true);
            grid.ShowAttackRange(selectedTarget, true);           
        }
        else if (onObject.hasMoved && !onObject.hasAttacked)
        {
            grid.ShowAttackRange(selectedTarget, true);
        }
    }

    public void deselectTarget()
    {
        if (selectedTarget != null)
        {
            grid.ShowMovementRange(selectedTarget, false);
            grid.ShowAttackRange(selectedTarget, false);
        }
        selectedTarget = null;
        targetSelected = false;
        selectedUI.UpdateToNone();
    }

    public bool IsReachable(Vector3 destination, Vector3[] reachable)
    {

        if (Array.Exists<Vector3>(reachable, element => element == destination)) return true;
        else return false;
    }

    private void updateCursor()
    {
        onTarget = false; blocked = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(controls[0]) && !(transform.position.z == (gridsizeZ * 10)))
        {   //UP
            updateCursor();
            transform.position = (transform.position + (new Vector3(0, 0, 10f)));
        }
        if (Input.GetKeyDown(controls[2]) && !(transform.position.z == 0f))
        {   //DOWN
            updateCursor();
            transform.position = (transform.position + (new Vector3(0, 0, -10f)));
        }
        if (Input.GetKeyDown(controls[1]) && !(transform.position.x == 0f))
        {   //LEFT
            updateCursor();
            transform.position = (transform.position + (new Vector3(-10f, 0, 0)));
        }
        if (Input.GetKeyDown(controls[3]) && !(transform.position.x == (gridsizeX * 10f)))
        {   //RIGHT
            updateCursor();
            transform.position = (transform.position + (new Vector3(10f, 0, 0)));
        }
        if (Input.GetKeyDown(controls[4]) && targetSelected)
        {   //ACTION
            if (!(blocked || onTarget))
            {
                if (IsReachable(transform.position, grid.movementRangeArray))
                {
                    selectedTarget.Move(transform.position.x, transform.position.z);
                    deselectTarget();
                }
            }
            if(onTarget){
                selectedTarget.Attack(onObject);
                if(selectedTarget.hasAttacked) deselectTarget();
            }
        }                              
        if (Input.GetKeyDown(controls[5]) && onObject.player == gameState.playerTurn)
        {   //SELECT
            if (onTarget)
            {
                selectTarget();
            }
            else
            {
                deselectTarget();
            }
        }
    }

}