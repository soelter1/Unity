using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehaviourScript : MonoBehaviour
{

    public float radius = 5.0f;
    public float force = 5.0f;

    private GameObject projectile;

    public Cursor cursor;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<Cursor>();
    }

    private void destroyProjectile()
    {
        Destroy(projectile);
    }

    int GetPlayer(GameObject projectile)
    {
        Debug.Log(projectile.layer);

        if (projectile.layer == 8) return 1;
        else if (projectile.layer == 9) return 2;
        else return 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        projectile = other.gameObject;

        if (other.gameObject.tag == "NonLethalProjectile")
        {
            int projectileDamage = projectile.GetComponent<ProjectileBehaviourScript>().damage;

            if(this.gameObject.GetComponent<MoveAbleObject>().hp - projectileDamage <= 0)
            {
                Debug.Log("my projectiles damage is " + projectileDamage);

                projectile.tag = "LethalProjectile";
            }
        }

        if (other.gameObject.tag == "LethalProjectile")
        {
            int projectileDamage = projectile.GetComponent<ProjectileBehaviourScript>().damage;

            Debug.Log("my projectiles damage is " + projectileDamage);

            Debug.Log("triggered by " + other.name);
            Rigidbody[] colliders = gameObject.GetComponentsInChildren<Rigidbody>();

            MoveAbleObject target = this.gameObject.GetComponent<MoveAbleObject>();

            target.getsDamaged(GetPlayer(projectile), projectileDamage);
            target.explosionSound.Play();

            if (target.explosionSound != null) target.explosionSound.Play();


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
            int projectileDamage = projectile.GetComponent<ProjectileBehaviourScript>().damage;

            Debug.Log("my projectiles damage is " + projectileDamage);

            this.gameObject.GetComponent<MoveAbleObject>().getsDamaged(GetPlayer(projectile), projectileDamage);

            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;
            //other.attachedRigidbody.useGravity = true;
            other.attachedRigidbody.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
            Invoke("destroyProjectile", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
