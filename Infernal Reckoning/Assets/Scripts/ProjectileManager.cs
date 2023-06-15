using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject projectile;
    public ParticleSystem gunfire;
    public Animation recoil;
    private float timer;
    public float fireRate;
    public AudioSource pew;

    public int magazineSize = 30;
    public int maxReserve = 999;
    public int startingAmmo = 150;

    public int currentAmmo;
    private int reserveAmmo;
    public TMP_Text ammoText;
    
    

    private void Start()
    {
        currentAmmo = magazineSize;
        reserveAmmo = startingAmmo;
        UpdateAmmoText();

        currentAmmo = Mathf.Clamp(startingAmmo, 0, magazineSize);
        reserveAmmo = Mathf.Clamp(startingAmmo - magazineSize, 0, maxReserve);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < magazineSize && reserveAmmo > 0)
        {
            // Reload the gun
            int ammoNeeded = magazineSize - currentAmmo;

            int ammoToReload = Mathf.Min(ammoNeeded, reserveAmmo);
            currentAmmo += ammoToReload;
            reserveAmmo -= ammoToReload;
            UpdateAmmoText();
        }
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                Instantiate(projectile, spawnPosition.position, spawnPosition.rotation, null);
                gunfire.Play();
                recoil.Play();
                timer = 0;
                pew.Play();
                currentAmmo--;
                UpdateAmmoText();
            }
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            timer = fireRate;
        }
    }
    private void UpdateAmmoText()
    {
        ammoText.text = currentAmmo + "/" + reserveAmmo;
    }
    public void AddAmmo(int amount)
    {
        reserveAmmo += amount;
        reserveAmmo = Mathf.Clamp(reserveAmmo, 0, maxReserve);
        UpdateAmmoText();
    }
}
