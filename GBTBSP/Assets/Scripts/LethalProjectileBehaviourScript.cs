using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalProjectileBehaviourScript : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public float projectileLife = 20f;
    public GameObject Barrel;
    public GameObject Projectil;

    void OnEnable()
    {
        Projectil.tag = "LethalProjectile";

        Vector3 barrelPos = Barrel.transform.position;

        Debug.Log("nonlethal fire player1");
        Quaternion q = Quaternion.Euler(transform.eulerAngles - GetComponent<MoveAbleObject>().eulerAngles);
        Debug.Log(transform.gameObject + ":" + q);
        GameObject projectile = Instantiate(Projectil, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), q);      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed, ForceMode.Impulse);
        Destroy(projectile, projectileLife);

        /*

        Vector3 barrelPos = Barrel.transform.position;

        if (gameObject.GetComponentInParent<MoveAbleObject>().player == 1)
        {
            Debug.Log("lethal fire player1");
            GameObject projectile = Instantiate(Projectil, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
            projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, projectileSpeed), ForceMode.Impulse);
            Destroy(projectile, projectileLife);
        }
        else if (gameObject.GetComponentInParent<MoveAbleObject>().player == 2)
        {
            Debug.Log("lethal fire player2");
            GameObject projectile = Instantiate(Projectil, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), Quaternion.Euler(new Vector3(transform.rotation.x + 180, transform.rotation.y, transform.rotation.z)));      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
            projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -projectileSpeed), ForceMode.Impulse);
            Destroy(projectile, projectileLife);
        }

    */
    }
}
