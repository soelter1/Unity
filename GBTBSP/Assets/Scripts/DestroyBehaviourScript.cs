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
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider c in colliders)
        {
            if (c.tag == "Floor" || c.tag == "Cursor")
                continue;
            c.attachedRigidbody.isKinematic = false;
            c.attachedRigidbody.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
