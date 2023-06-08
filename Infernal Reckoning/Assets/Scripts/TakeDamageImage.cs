using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamageImage : MonoBehaviour
{
    public Image redScreen;
    public float damageEffectDuration = 0.5f;
    private float timer;

    private bool isTakingDamage;

    private void Start()
    {
        redScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTakingDamage)
        {
            timer += Time.deltaTime;
            redScreen.enabled = true;
            if (timer > damageEffectDuration)
            {
                isTakingDamage = false;
                redScreen.enabled = false;
            }
            
        }
    }
    public void TakeDamage()
    {
        isTakingDamage = true;
        timer = 0;
    }
}