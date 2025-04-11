using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireBullet : MonoBehaviour
{
    private Animator reloadAnimation;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public int bulletCount;
    [SerializeField]private GameObject ammoUIObject;
    public TMP_Text ammoUI;
    public bool canShoot;
    public bool isReloading;
    public MonoBehaviour gunSystem;

    void Start()
    {
        reloadAnimation = GetComponent<Animator>();
        canShoot = true;
        isReloading = false;
        
        
    }

    void Update()
    {
       // ammoUIObject = GameObject.Find("Ammo");
        if(ammoUIObject != null)
        {
            ammoUI = ammoUIObject.GetComponent<TMP_Text>();
            // Update the ammo count on the UI
            ammoUI.SetText(bulletCount.ToString());
        }
        else
        {

        }
        
        // Check if player is clicking the mouse, has bullets, and isn't currently reloading
        if (Input.GetMouseButtonDown(0) && canShoot && !isReloading)
        {
            reloadAnimation.SetBool("isReloading", false); // Ensure reload animation is off when shooting
            Shoot();
        }

        // Trigger reload when bulletCount reaches 0 and the player isn't already reloading
        if (bulletCount == 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        
    }

    void Shoot()
    {
        bulletCount--;
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawnPoint.forward * bulletSpeed;
    }

   
    IEnumerator Reload()
    {
        isReloading = true;  // Prevent shooting during reload
        reloadAnimation.SetBool("isReloading", true);  // Play reload animation
        gunSystem.enabled = false;

        yield return new WaitForSeconds(2f);  // Wait for the reload duration
        gunSystem.enabled = true;
        bulletCount = 25;  // Reset bullet count
        canShoot = true;  // Allow shooting again
        isReloading = false;  // Reloading process finished
        reloadAnimation.SetBool("isReloading", false);  // Stop reload animation
    }


}
