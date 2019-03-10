using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviourScript : MonoBehaviour
{
    float projectileSpeed = 3f;
    float projectileLife = 20f;
    public GameObject Projectil;

    void Start()
    {

        Vector3 barrelPos = gameObject.transform.position;

        //Debug.Log("A barrel want´s to shoot a projectile");
        if (gameObject.GetComponentInParent<MoveAbleObject>().player == 1)
        {
            Debug.Log("fire player1");
            GameObject projectile = Instantiate(Projectil, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
            projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, projectileSpeed), ForceMode.Impulse);
            Destroy(projectile, projectileLife);
        }
        else if (gameObject.GetComponentInParent<MoveAbleObject>().player == 2)
        {
            Debug.Log("fire player2");
            GameObject projectile = Instantiate(Projectil, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), Quaternion.Euler(new Vector3(transform.rotation.x + 180, transform.rotation.y, transform.rotation.z)));      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
            projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -projectileSpeed), ForceMode.Impulse);
            Destroy(projectile, projectileLife);
        }
    }
}
