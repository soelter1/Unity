using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonLethalProjectileBehaviourScript : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public float projectileLife = 20f;
    public GameObject[] Barrels;
    public GameObject Projectil;

    void OnEnable()
    {
        MoveAbleObject moveAbleObject = this.gameObject.GetComponent<MoveAbleObject>();

        foreach (GameObject barrel in Barrels)
        {
            Projectil.tag = "NonLethalProjectile";

            Vector3 barrelPos = barrel.transform.position;

            Debug.Log("nonlethal fire");
            GameObject projectile = Instantiate(Projectil, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), Quaternion.identity);      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
            projectile.GetComponent<ProjectileBehaviourScript>().damage = moveAbleObject.atk;
            Vector3 forward = GetComponent<MoveAbleObject>().globalForward;
            projectile.transform.LookAt(projectile.transform.position + forward, Vector3.up);
            projectile.GetComponent<Rigidbody>().AddForce(forward * projectileSpeed, ForceMode.Impulse);
            Destroy(projectile, projectileLife);
        }
    }
}
