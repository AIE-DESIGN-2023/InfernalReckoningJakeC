using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //Variables for health max and current health
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;
    
    private Transform canvas;
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        //Set current health to max health
        currentHealth = maxHealth;
        canvas = GetComponentInChildren<Canvas>().transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
       //Creating a new Vector3 that is the players x and z pos, but the canvas' y pos so it doesn't look up and down
        Vector3 positionTOLookAt = new Vector3(player.position.x, canvas.position.y, player.position.z);
       //Unity function that looks at whatever trasnform is passed to it
        canvas.LookAt(positionTOLookAt);
    }

    public void TakeDamage(int damageToTake)
    {
        //Remove damage from health
        currentHealth -= damageToTake;
        //Update the image to show new health
        healthBar.fillAmount = currentHealth / maxHealth;
        
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
