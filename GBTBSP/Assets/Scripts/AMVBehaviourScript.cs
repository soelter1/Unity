using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMVBehaviourScript : MonoBehaviour
{
    public float projectileSpeed = 100;
    public GameObject ProjectilPlayer1;
    public GameObject ProjectilPlayer2;
    float projectileLife = 20.0f;

    public GameObject Parent;



    // Update is called once per frame
    void Update()
    {

        Vector3 barrelPos = transform.position;

        if (Input.GetKeyDown("g"))
        {
            //projectile.AddComponent<Rigidbody>();            

            if (Parent.transform.rotation.y > 0)
            {
                Debug.Log("fire player2");
                GameObject projectile = Instantiate(ProjectilPlayer1, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), Quaternion.Euler(new Vector3(transform.rotation.x + 180, transform.rotation.y, transform.rotation.z)));      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
                projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -projectileSpeed), ForceMode.Impulse);
                Destroy(projectile, projectileLife);
            }
            else
            {

                Debug.Log("fire player1");
                GameObject projectile = Instantiate(ProjectilPlayer2, new Vector3(barrelPos.x, barrelPos.y, barrelPos.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));      //Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z))
                projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, projectileSpeed), ForceMode.Impulse);
                Destroy(projectile, projectileLife);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("onTrigger");
            Destroy(other.gameObject);
            gameObject.AddComponent<DestroyBehaviourScript>();
        }
    }
}
