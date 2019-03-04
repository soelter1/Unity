using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviourScript : MonoBehaviour
{

   public void showMovementRange(MoveAbleObject obj)
    {

        Debug.Log(obj.transform.position);

        FloorBehaviourScript[] floors = this.GetComponents<FloorBehaviourScript>();

        foreach(FloorBehaviourScript i in floors)
        {
            if(i.transform.position == new Vector3(obj.transform.position.x, 0, obj.transform.position.z))
            {
                i.transform.position = new Vector3(0, 0, 110);
            }
        }

        //int range = obj.movementRange;

        //Vector3 position= obj.transform.position;
    }
}
