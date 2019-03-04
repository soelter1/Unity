using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public MoveAbleObject selectedTarget;
    public MoveAbleObject onObject;
    public SelectedUI selectedUI;

    bool targetSelected = false;

    public bool onTarget = false;
    public bool blocked = false;

    private void OnGUI()
    {
        if(Input.GetKeyDown("w")){
            onTarget = false;
            blocked = false;
            transform.position = (transform.position+(new Vector3(0, 0, 2.5f)));
        }
        if (Input.GetKeyDown("s"))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(0, 0, -2.5f)));
        }
        if (Input.GetKeyDown("a"))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(-2.5f,0,0)));
        }
        if (Input.GetKeyDown("d"))
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
    }

}
