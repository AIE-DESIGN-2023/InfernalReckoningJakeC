using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamageImage : MonoBehaviour
{
    //Unity UI image of a partially transparent red image
    public Image redScreen;
    //Sets the duration of the above image appearing on screen
    public float damageEffectDuration = 0.5f;
    //Timer to keep track of the above damage effect
    private float timer;

    //Checks if the player is currently taking damage
    private bool isTakingDamage;

    private void Start()
    {
        //The game starts with the red screen effect turned off
        redScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTakingDamage)
        {
            //Counts the time since the last frame
            timer += Time.deltaTime;
            //Sets the red image on
            redScreen.enabled = true;
            //Checks if timer has reached the duration
            if (timer > damageEffectDuration)
            {

                //Not taking damage and turns screen effect off
                isTakingDamage = false;
                redScreen.enabled = false;
            }

        }
    }
    public void TakeDamage()
    {
        //Resets check for damage and turns screen effect off
        isTakingDamage = true;
        timer = 0;
    }
}
