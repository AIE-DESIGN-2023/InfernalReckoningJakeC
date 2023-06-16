using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    //Variables for enemies left, total enemies, text display, win canvas, lose canvas
    public int enemiesLeft;
    public int enemiesTotal;
    public TMP_Text enemiesText;
    public Canvas winCanvas, loseCanvas;
    GameObject[] enemies;
    public FirstPersonController firstPersonController;





    // Start is called before the first frame update
    void Start()
    {
        //find all enemies in the scene and assign the total count to the amount it finds
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesTotal = enemies.Length;

        //Assign the Text the value of remaining and total enemies
        enemiesText.text = enemiesTotal + "/" + enemiesTotal + " enemies left";

        //Turning of the win and lose canvas
        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //find all enemies in the scene and assign the remaining count to the amount it finds
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        //Assign the text the value of remaining enemies
        enemiesText.text = enemiesLeft + "/" + enemiesTotal + " remaining";

        //check if there are any enemies left, if not player wins, turns on the canvas
        if(enemiesLeft == 0)
        {
            //Turns on the canvas game objust
            winCanvas.gameObject.SetActive(true);
            //unlocks the cursor
            Cursor.lockState = CursorLockMode.None;
            firstPersonController.DisableMovement();
            
            
        }
    }
    public void PlayerDies()
    {
        loseCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
