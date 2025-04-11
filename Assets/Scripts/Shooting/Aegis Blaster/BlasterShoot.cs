using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlasterShoot : MonoBehaviour
{
    private Animator reloadAnimation;
    public bool isReloading;
    public MonoBehaviour gunSystem;
    public float bulletCount;
    public bool canShoot;
    public GameObject energyRoundPrefab;
    [SerializeField] private GameObject ammoUIObject;
    public TMP_Text ammoUI;
    public Transform firingPoint;
    public float roundSpeed = 50f;
    public float cooldownTime = 1f; // Time between shots

    [SerializeField] private GameObject ammoHolder;
    [SerializeField] private Ammo rocketAmmo;

    private void Start()
    {
        gunSystem = GetComponent<GunSystem>();
        reloadAnimation = GetComponent<Animator>();
        canShoot = true;
        isReloading = false;

        if (ammoHolder != null)
        {
            rocketAmmo = ammoHolder.GetComponent<Ammo>();
        }

        if (bulletCount == 0)
        {
            StartCoroutine(Reload());
        }
    }

    void Update()
    {
        if (ammoUIObject != null)
        {
            ammoUI = ammoUIObject.GetComponent<TMP_Text>();
            ammoUI.SetText(bulletCount.ToString());
        }

        if (Input.GetMouseButtonDown(0) && canShoot && !isReloading && bulletCount > 0)
        {
            reloadAnimation.SetBool("isReloading", false);
            StartCoroutine(FireShot());
        }

        if (rocketAmmo.CheckBlaster() > 0)
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

    IEnumerator FireShot()
    {
        canShoot = false;
        bulletCount--;
        FireRound();
        yield return new WaitForSeconds(cooldownTime);
      //  canShoot = true;
    }

    void FireRound()
    {
        GameObject round = Instantiate(energyRoundPrefab, firingPoint.position, firingPoint.rotation);
        Rigidbody rb = round.GetComponent<Rigidbody>();
        rb.linearVelocity = firingPoint.forward * roundSpeed;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadAnimation.SetBool("isReloading", true);
        yield return new WaitForSeconds(1f); // Adjust reload time as needed
        bulletCount = 1;
        isReloading = false;
        canShoot = true;
        reloadAnimation.SetBool("isReloading", false);
    }
}
