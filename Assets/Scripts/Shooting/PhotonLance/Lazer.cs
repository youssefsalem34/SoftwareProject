using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Lazer : MonoBehaviour
{
    public float baseDamage; // Starting damage
    public float maxDamage; // Maximum damage
    public float chargeRate; // Damage increase per second
    public float range = 100f;
    public ParticleSystem flash;
    [SerializeField] private GameObject ray;
    [SerializeField] private Slider lazerSlider;
    [SerializeField] private float overHeat;
    [SerializeField] private float overHeatAdd;
    [SerializeField] private GameObject raycastPosition;
    [SerializeField] private GameObject overheatSound;
    [SerializeField] private AudioSource overheatedSound;

    public GameObject sphere;
    public Camera playerCamera; // Reference to the player's camera

    [SerializeField]private float currentDamage; // Tracks the current damage
  [SerializeField]  private bool isCharging; // Tracks if the button is held down


    [SerializeField] private GameObject ammoHolder;
    [SerializeField] private Ammo laserAmmo;
    private void Start()
    {
        ray.SetActive(false);
        isCharging = true;
    }
    void Update()
    {
        if (overHeat >= 55 && overHeat < 100)
        {
            overheatSound.SetActive(true);
        }
        else if (overHeat == 0)
        {
            overheatSound.SetActive(false);
        }
        lazerSlider.value = overHeat;
        lazerSlider.maxValue = maxDamage;
        // Make the sphere rotate to face where the camera is looking
        sphere.transform.rotation = playerCamera.transform.rotation;
      

        if (laserAmmo.CheckLaser() >= 0)
        {
            if (Input.GetButton("Fire1") && isCharging)
            {
                // Start charging damage

                currentDamage += chargeRate * Time.deltaTime;
                overHeat += overHeatAdd * Time.deltaTime;
                currentDamage = Mathf.Clamp(currentDamage, baseDamage, maxDamage);
                ray.SetActive(true);

                Shoot();
               

                if (overHeat >= 100)
                {
                    overHeat = 0;
                    StartCoroutine(StopShooting());
                }
            }
            
            else
            {
                // isCharging = false;

                // Reset damage when the button is released
                currentDamage = baseDamage;
                overHeat = 0;
                ray.SetActive(false);
            }
        }



        if (laserAmmo.CheckLaser() <= 0)
        {
            ray.SetActive(false);       
        }


    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPosition.transform.position, raycastPosition.transform.forward, out hit, range))
        {
            laserAmmo.DeducLaser(1 * Time.deltaTime);
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log($"Hit {hit.transform.name} with {currentDamage} damage");

                AttributeManager targetHealth = hit.transform.GetComponent<AttributeManager>();
                if (targetHealth != null)
                {
                    targetHealth.ReduceEnemyHealth(currentDamage);
                }
            }
            // flash.Play();
           

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Draw the ray
        Gizmos.DrawRay(raycastPosition.transform.position, raycastPosition.transform.forward * range);
    }


    IEnumerator StopShooting( )
    {
        isCharging = false;
        currentDamage = baseDamage;
        overheatedSound.Play();
        ray.SetActive(false);
        yield return new WaitForSeconds(5f);
        isCharging = true;


    }
}