using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehaviourScript : MonoBehaviour
{

    public float radius = 5.0f;
    public float force = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody[] colliders = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody c in colliders)
        {
            if (c.tag == "Floor" || c.tag == "Cursor")
                continue;
            c.isKinematic = false;
            c.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
