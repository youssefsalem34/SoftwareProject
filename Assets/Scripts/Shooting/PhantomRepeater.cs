using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhantomRepeater : MonoBehaviour
{
    private Animator reloadAnimation;
    public bool isReloading;
   // public MonoBehaviour gunSystem;
    public float bulletCount;
    public bool canShoot;
    public GameObject energyRoundPrefab;
    [SerializeField] private GameObject ammoUIObject;
    public TMP_Text ammoUI;
    public Transform firingPoint;
    public float roundSpeed = 50f;
    public int burstSize = 3;
    public float burstRate = 0.1f; // Time between rounds in a burst
    public float cooldownTime = 1f; // Time between bursts
    [SerializeField] private AudioSource shootSound;

    [SerializeField] private GameObject ammoHolder;
    [SerializeField] private Ammo rocketAmmo;

    //private bool canFire = true;


    private void Start()
    {
      //  gunSystem = GetComponent<GunSystem>();
        reloadAnimation = GetComponent<Animator>();
        canShoot = true;
        isReloading = false;


        if (ammoHolder != null)
        {
            rocketAmmo = ammoHolder.GetComponent<Ammo>();
        }
    }
    void Update()
    {
        if (ammoUIObject != null)
        {
            ammoUI = ammoUIObject.GetComponent<TMP_Text>();
            // Update the ammo count on the UI
            ammoUI.SetText(bulletCount.ToString());
        }
        else
        {

        }
        if (Input.GetMouseButtonDown(0) && canShoot && !isReloading && bulletCount > 0)
        {
            reloadAnimation.SetBool("isReloading", false);
            StartCoroutine(FireBurst());
            shootSound.Play();

        }
        if (rocketAmmo.CheckBullets() > 0)
        {
           
             if (bulletCount <= 0 && !isReloading)
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
            Debug.Log("No Bullets");
        }




    }

    IEnumerator FireBurst()
    {
        //  canFire = false;
        bulletCount -= 3;
        for (int i = 0; i < burstSize; i++)
        {
            FireRound();
            yield return new WaitForSeconds(burstRate);
            
        }

        yield return new WaitForSeconds(cooldownTime);
       // canFire = true;
    }

    void FireRound()
    {
        GameObject round = Instantiate(energyRoundPrefab, firingPoint.position, firingPoint.rotation);
        Rigidbody rb = round.GetComponent<Rigidbody>();
        rb.linearVelocity = firingPoint.forward * roundSpeed;
        
        // Ignore collisions with walls, only detect enemies
      //  Physics.IgnoreLayerCollision(LayerMask.NameToLayer("EnergyRound"), LayerMask.NameToLayer("Wall"), true);
    }


    IEnumerator Reload()
    {
        isReloading = true;  // Prevent shooting during reload
        reloadAnimation.SetBool("isReloading", true);  // Play reload animation
       // gunSystem.enabled = false;

        yield return new WaitForSeconds(2f);  // Wait for the reload duration
        rocketAmmo.DeducAmmo(25);

       // gunSystem.enabled = true;
        bulletCount = 25;  // Reset bullet count
        canShoot = true;  // Allow shooting again
        isReloading = false;  // Reloading process finished
        reloadAnimation.SetBool("isReloading", false);  // Stop reload animation
    }
}