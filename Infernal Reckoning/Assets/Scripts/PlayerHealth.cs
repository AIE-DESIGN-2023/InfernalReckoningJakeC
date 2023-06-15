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
    public Sprite okay;
    public Sprite hurt;

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
        if (currentHealth < 33)
            avatar.sprite = hurt;
        else if (currentHealth < 66)
            avatar.sprite = okay;
        else
            avatar.sprite = healthy;

    }
}
