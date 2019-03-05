using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class GridBehaviourScript : MonoBehaviour
{

    public FloorBehaviourScript[] floors;

    Renderer rend;

    Shader Ground1;
    Shader Ground2;
    Shader Range;

    public void showMovementRange(MoveAbleObject obj)
    {

        Debug.Log(obj.transform.position);

        floors = GetComponentsInChildren<FloorBehaviourScript>();

        Debug.Log(floors.Length);

        Vector3 objPos = obj.transform.position;

        int movementRange = obj.movementRange;

        int primeRange = movementRange * 2 + 1;

        Debug.Log("movementRange: " + movementRange + "primeRange: " + primeRange);

        Vector3[] rangeArray = new Vector3[primeRange * primeRange];

        Debug.Log("rangeArray Length: " + rangeArray.Length);

        Vector3[] reachable = makeRangeArray(rangeArray, objPos, movementRange);

        foreach (FloorBehaviourScript i in floors)
        {
            bool a = Array.Exists<Vector3>(reachable, Vector3 => Vector3 == i.transform.position); //new Vector3(obj.transform.position.x, 0, obj.transform.position.z)

            if (a)
            {
                Debug.Log(i + "is reachable");
                rend = i.GetComponent<MeshRenderer>();

                rend.material.shader = Range;
            }
        }
    }

    Vector3[] makeRangeArray(Vector3[] rangeArray, Vector3 objPos, int movementRange)
    {
        //rangeArray[0] = objPos;

        rangeArray[0] = new Vector3(objPos.x, 0, objPos.z + (movementRange * 10));

        return rangeArray;
    }
}
