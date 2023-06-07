using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBillboard : MonoBehaviour
{
    Vector3 cameraDir;
    EnemyManagerStateMachine enemyManager;
    public Sprite patrol;
    public Sprite aggro;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GetComponent<EnemyManagerStateMachine>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraDir = Camera.main.transform.forward;
        cameraDir.y = 0;

        transform.rotation = Quaternion.LookRotation(cameraDir);
        if (enemyManager.enemyState != EnemyManagerStateMachine.EnemyState.patrol)
        {
            spriteRenderer.sprite = aggro;
        }
    }
}
