using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 75, -20);
    public bool Sight = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        if (Sight) { transform.rotation = target.rotation; }
    }

}
