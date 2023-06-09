using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBillboard : MonoBehaviour
{
    //Stores the direction from the sprite to the camera
    Vector3 cameraDir;
    //Script for determining the enemy state
    EnemyManagerStateMachine enemyManager;
    //Assign a 2D sprite for when the enemy is partrolling
    public Sprite patrol;
    //Assign a 2D sprite for when the enemy is aggro
    public Sprite aggro;
    //Unity Sprite renderer
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning these variables with components on the game object that this script is also attached to
        enemyManager = GetComponent<EnemyManagerStateMachine>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the forward direction of the main camera
        cameraDir = Camera.main.transform.forward;
        //Set the Y value to zero, ignore verticality 
        cameraDir.y = 0;

        // Rotate the sprite to face the camera
        transform.rotation = Quaternion.LookRotation(cameraDir);
        //Sets the sprite to either Patrol or Aggro depending on enemy state
        if (enemyManager.enemyState != EnemyManagerStateMachine.EnemyState.patrol)
        {
            spriteRenderer.sprite = aggro;
        }
    }
}
