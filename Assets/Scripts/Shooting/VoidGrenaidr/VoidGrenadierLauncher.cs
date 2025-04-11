using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoidGrenadierLauncher : MonoBehaviour
{
  //  private Animator reloadAnimation;
    public GameObject rocketPrefab;
    public Transform rocketSpawnPoint;
    public float rocketSpeed = 1;
    public int rocketCount;
    [SerializeField] private GameObject ammoUIObject;
    public TMP_Text ammoUI;
    public bool canShoot;
    public bool isReloading;

    [SerializeField] private GameObject ammoHolder;
    [SerializeField] private Ammo rocketAmmo;
   // public MonoBehaviour gunSystem;

    void Start()
    {
      //  reloadAnimation = GetComponent<Animator>();
        canShoot = true;
        isReloading = false;

        if(ammoHolder != null)
        {
            rocketAmmo = ammoHolder.GetComponent<Ammo>();
        }
    }

    void Update()
    {
       // ammoUIObject = GameObject.Find("Ammo");
        if (ammoUIObject != null)
        {
            ammoUI = ammoUIObject.GetComponent<TMP_Text>();
            // Update the ammo count on the UI
            ammoUI.SetText(rocketCount.ToString());
        }
        else
        {

        }

        // Check if player is clicking the mouse, has bullets, and isn't currently reloading
        if (Input.GetMouseButtonDown(0) && canShoot && !isReloading && rocketCount == 1)
        {
           // reloadAnimation.SetBool("isReloading", false); // Ensure reload animation is off when shooting
            Shoot();
        }

        if(rocketAmmo.CheckRockets() > 0)
        {
            // Trigger reload when bulletCount reaches 0 and the player isn't already reloading

            if (rocketCount == 0 && !isReloading)
            {
                StartCoroutine(Reload());
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }

        }
        else
        {
            Debug.Log("No more ammo");
        }


    }

    void Shoot()
    {
        rocketCount--;
        var bullet = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, rocketSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = rocketSpawnPoint.forward * rocketSpeed;
    }


    IEnumerator Reload()
    {
        isReloading = true;  // Prevent shooting during reload
       // reloadAnimation.SetBool("isReloading", true);  // Play reload animation
     //   gunSystem.enabled = false;

        yield return new WaitForSeconds(2f);  // Wait for the reload duration
       // gunSystem.enabled = true;
        rocketCount = 1;  // Reset bullet count
        rocketAmmo.DeducRocket(1);
        canShoot = true;  // Allow shooting again
        isReloading = false;  // Reloading process finished
       // reloadAnimation.SetBool("isReloading", false);  // Stop reload animation
    }


}
