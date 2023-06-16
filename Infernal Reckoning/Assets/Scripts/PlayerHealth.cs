using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Image healthBar;
    private GameStateManager gameStateManager;
    private TakeDamageImage damageImage;
   
    public Image avatar;
    public Sprite healthy;
    public Sprite ninety;
    public Sprite eighty;
    public Sprite seventy;
    public Sprite sixty;
    public Sprite fifty;
    public Sprite forty;
    public Sprite thirty;
    public Sprite twenty;
    public Sprite ten;
    public Sprite dead;



    // Start is called before the first frame update
    void Start()
    {
       avatar.sprite = healthy;
        currentHealth = maxHealth;
        gameStateManager = FindObjectOfType<GameStateManager>();
        damageImage = FindObjectOfType<TakeDamageImage>();

    }

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;

        healthBar.fillAmount = currentHealth / maxHealth;

        if (damageToTake > 0)
        {
            damageImage.TakeDamage();
        }
            

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0)
        {
            gameStateManager.PlayerDies();
            //UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
        if (currentHealth <= 0)
            avatar.sprite = dead;
        else if (currentHealth < 11)
            avatar.sprite = ten;
        else if (currentHealth < 21)
            avatar.sprite = twenty;
        else if (currentHealth < 31)
            avatar.sprite = thirty;
        else if (currentHealth < 41)
            avatar.sprite = forty;
        else if (currentHealth < 51)
            avatar.sprite = fifty;
        else if (currentHealth < 61)
            avatar.sprite = sixty;
        else if (currentHealth < 71)
            avatar.sprite = seventy;
        else if (currentHealth < 81)
            avatar.sprite = eighty;
        else if (currentHealth < 91)
            avatar.sprite = ninety;
        else
            avatar.sprite = healthy;

    }
}
