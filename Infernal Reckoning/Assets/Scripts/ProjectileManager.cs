using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject projectile;
    public ParticleSystem gunfire;
    public Animation recoil;
    private float timer;
    public float fireRate;
    public AudioSource pew;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                Instantiate(projectile, spawnPosition.position, spawnPosition.rotation, null);
                gunfire.Play();
                recoil.Play();
                timer = 0;
                pew.Play();
            }
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            timer = fireRate;
        }
    }
}
