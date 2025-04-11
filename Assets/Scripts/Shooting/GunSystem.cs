using UnityEngine;
using TMPro;


public  class GunSystem : MonoBehaviour
{
   public float damage;
  public float range = 100f;
  public ParticleSystem flash;

  public Camera fpsCam;

  void Update(){
    if (Input.GetButtonDown("Fire1"))
    {
        Shoot();
    }
  }


  void Shoot()
  {
    RaycastHit hit;
    if(Physics.Raycast(fpsCam.transform.position,  fpsCam.transform.forward, out hit, range))
    {
        flash.Play();
        Debug.Log(hit.transform.name);

        AttributeManager targetHealth = hit.transform.GetComponent<AttributeManager>();
        if(targetHealth != null)
        {
            targetHealth.ReduceEnemyHealth(damage);
        }
    }
  }

void OnDrawGizmos()
{
  Gizmos.color = Color.red;

        // Draw the ray
        Gizmos.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range);
}

}
