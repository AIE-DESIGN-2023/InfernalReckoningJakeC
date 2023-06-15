using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //Variable for the amount of ammo to give player
    public int ammoAmount = 45;
    
    public float respawnTime = 1f; // Time in seconds before respawn

    private GameObject originalObject;
    private bool isRespawning = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ProjectileManager projectileManager = other.GetComponent<ProjectileManager>();

            if (projectileManager.maxReserve <= 999)
            {
                projectileManager.AddAmmo(ammoAmount);

                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                isRespawning = true;
                Invoke("Respawn", respawnTime);
            }
        }
    }
    private void Respawn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        //GameObject respawnedObject = Instantiate(originalObject, transform.position, transform.rotation);
        //respawnedObject.SetActive(true);
        isRespawning = false;
    }
}
    
    