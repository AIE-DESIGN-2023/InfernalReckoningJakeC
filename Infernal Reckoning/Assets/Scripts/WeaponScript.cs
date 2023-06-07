using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //Variable for the new bullet prefab
    public GameObject bullet;

    private ProjectileManager projectileManager;

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if it is the player colliding
        if (other.gameObject.tag == "Player")
        {
            //Get the projectile manager script and reassign the object to instantiate
            other.GetComponent<ProjectileManager>().projectile = bullet;
        }
    }
}
