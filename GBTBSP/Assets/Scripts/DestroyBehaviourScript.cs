using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehaviourScript : MonoBehaviour
{

    public float radius = 5.0f;
    public float force = 10.0f;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            Collider[] colliders = Physics.OverlapSphere(hit.point, radius);

            foreach (Collider c in colliders)
            {
                c.attachedRigidbody.AddExplosionForce(force, hit.point, radius, 0.5f, ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
