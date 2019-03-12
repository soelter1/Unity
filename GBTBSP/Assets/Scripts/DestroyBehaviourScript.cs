using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehaviourScript : MonoBehaviour
{

    public float radius = 5.0f;
    public float force = 10.0f;

    private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void destroyProjectile()
    {
        Destroy(projectile);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LethalProjectile")
        {
            Debug.Log("triggered by " + other.name);
            projectile = other.gameObject;
            Rigidbody[] colliders = gameObject.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody c in colliders)
            {
                c.isKinematic = false;
                c.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
            }
            Invoke("destroyProjectile", 0.1f);
            Destroy(this.gameObject, 1.5f);
        }

        if (other.gameObject.tag == "NonLethalProjectile")
        {
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;
            other.attachedRigidbody.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
            Invoke("destroyProjectile", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
