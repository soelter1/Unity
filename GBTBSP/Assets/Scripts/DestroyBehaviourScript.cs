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

        Debug.Log("Destroy Behavoir appended to " + gameObject.name);

        /*
        Rigidbody[] colliders = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody c in colliders)
        {
            if (c.tag == "Floor" || c.tag == "Cursor")
                continue;
            c.isKinematic = false;
            c.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
        }

    */
    }

    private void destroyProjectile()
    {
        Destroy(projectile);
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("triggered by " + other.name);


        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("onTrigger");
            projectile = other.gameObject;
            Rigidbody[] colliders = gameObject.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody c in colliders)
            {
                c.isKinematic = false;
                c.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
            }
            Invoke("destroyProjectile", 20f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
