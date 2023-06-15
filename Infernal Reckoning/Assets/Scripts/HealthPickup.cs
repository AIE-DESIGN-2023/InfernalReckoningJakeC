using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float respawnTime = 1f; // Time in seconds before respawn

    private GameObject originalObject;
    private bool isRespawning = false;
    //Variable for the amount of health to give player
    public int healthPickupAmount;
    private void OnTriggerEnter(Collider other)
    {
       //Check that it is the player that is colliding
        if(other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            //Destroy the health box
            if(playerHealth.currentHealth < playerHealth.maxHealth)
            {
                //Call into the player health script to give health
                playerHealth.TakeDamage(-healthPickupAmount);
                
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
