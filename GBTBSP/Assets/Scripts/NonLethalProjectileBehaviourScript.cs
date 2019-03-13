using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonLethalProjectileBehaviourScript : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public float projectileLife = 20f;
    public GameObject Barrel;
    public GameObject Projectil;

    void OnEnable()
    {
        Projectil.tag = "NonLethalProjectile";

        Vector3 barrelPos = Barrel.transform.position;

            Debug.Log("nonlethal fire player1");
            Quaternion q = Quaternion.Euler(transform.eulerAngles - GetComponent<MoveAbleObject>().eulerAngles);
            Debug.Log(transform.gameObject+":"+ q);
            GameObject projectile = Instantiate(Projectil, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), q);      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward* projectileSpeed, ForceMode.Impulse);
            Destroy(projectile, projectileLife);
    }
}
