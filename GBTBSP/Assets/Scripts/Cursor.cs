using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public MoveAbleObject selectedTarget;
    public MoveAbleObject onObject;
    public SelectedUI selectedUI;
    public GridBehaviourScript grid;

    public int gridsizeX;
    public int gridsizeZ;

    bool targetSelected = false;

    public bool onTarget = false;
    public bool blocked = false;

    private void OnGUI()
    {
        if(Input.GetKeyDown("w") && !(transform.position.z == (gridsizeZ*10)))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position+(new Vector3(0, 0, 2.5f)));
        }
        if (Input.GetKeyDown("s") && !(transform.position.z == 0f))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(0, 0, -2.5f)));
        }
        if (Input.GetKeyDown("a") && !(transform.position.x == 0f))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(-2.5f,0,0)));
        }
        if (Input.GetKeyDown("d") && !(transform.position.x == (gridsizeX*10f)))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(2.5f, 0, 0)));
        }
        if (Input.GetKeyDown("space") && targetSelected && !(blocked || onTarget))
        {
            selectedTarget.transform.position = new Vector3(transform.position.x, selectedTarget.transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown("f"))
        {
            if (onTarget)
            {
                selectedTarget = onObject;
                targetSelected = true;
                selectedUI.UpdateName(selectedTarget.unitName);
            }
            else
            {
                selectedTarget = null;
                targetSelected = false;
                selectedUI.UpdateName("None");
            }
        }

        if (Input.GetKeyDown("l"))
        {
            grid.showMovementRange(selectedTarget);
        }
    }

}
