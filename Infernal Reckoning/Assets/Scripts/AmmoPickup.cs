using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //Variable for the amount of ammo to give player
    public int ammoAmount = 45;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ProjectileManager projectileManager = other.GetComponent<ProjectileManager>();

            if (projectileManager.maxReserve <= 999)
            {
                projectileManager.AddAmmo(ammoAmount);

                Destroy(gameObject);
            }
        }
    }
}
    
    