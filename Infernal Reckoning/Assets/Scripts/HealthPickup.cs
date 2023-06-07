using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
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
                Destroy(gameObject);
            }
            


        }
    }
}
