using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : NetworkBehaviour
{

    public float radius;  // Radius of the sphere

    [SerializeField] private Slider healthSlider;
    [SerializeField] public bool playerDead;
    [SerializeField] private GameObject resetPos;
    [SerializeField] private GameObject resetObjPos;
    [SerializeField] private GameObject resetKeys;
    [SerializeField] private GameObject resetpayload;
    [SerializeField] private GameObject resetpayloadPos;
    [SerializeField] private GameObject resetFirstPos;
    [SerializeField] private Ammo resetAmmo;
    [SerializeField] private AttributeManager playerHealth;
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private GameObject playerDeathUI;

    [SerializeField] private Timer timerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // resetAmmo = GetComponent<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value <= 0)
        {
            playerDead = true;
            playerHealth.resetHealth = true;
            //playerHealth.IncreaseHealth(playerHealth.CheckHealth());
        }
        if (!IsOwner)
        {
            return;
        }

        if (IsLocalPlayer)
        {
            CheckPlayerDeath();
        }
            
    }

    void CheckPlayerDeath()
    {
       if (playerDead)
        {
            playerDeath.Play();
            //Player death here. Restart room
            KillAllEnemiesInRoom();
            ResetPlayerPosition();
            ResetObjective();
           StartCoroutine( RoomResetUI());
            
            playerDead = false; 
       }
    }


    void KillAllEnemiesInRoom() //Reset Enemies
    {
        //Overlap sphere to remove all the enemies in the room
        Vector3 sphereCenter = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(sphereCenter, radius);
        foreach (Collider hitCollider in hitColliders)
        {
           if (hitCollider.gameObject.CompareTag("Enemy"))
           {

             Destroy(hitCollider.gameObject);
           }

           if (hitCollider.gameObject.CompareTag("Enemy2"))
            {
                Destroy(hitCollider.gameObject);
            }

           if (hitCollider.gameObject.CompareTag("resetPos"))
            {
                resetPos = hitCollider.gameObject;
            }
        }

    }

    void ResetPlayerPosition() //Reset player position
    {
        //change player transform
        if (resetPos != null)
        {
            this.transform.position = resetPos.transform.position;
        }
       
    }

    void ResetObjective() //Reset objective
    {
        //Overlap sphere to check what objective is currently in the room and resets it
        Vector3 sphereCenter = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(sphereCenter, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("obj1"))
            {
                resetFirstPos = hitCollider.gameObject;
            }
            else
            {
                Debug.Log("No third objective");
            }

            

            if (hitCollider.gameObject.CompareTag("FirstObjective"))
            {
                resetObjPos = hitCollider.gameObject;
                
                EliminateEnemies enemyCounter = resetObjPos.gameObject.GetComponent<EliminateEnemies>();
               
                enemyCounter.numberOfEnemiesKilled = 0;
                resetAmmo.AddAmmo(25);
                resetAmmo.AddRockets(2);
                resetAmmo.AddLaser(15);


            }
            else if (hitCollider.gameObject.CompareTag("SecondObjective"))
            {
                resetObjPos = hitCollider.gameObject;
                resetKeys = hitCollider.gameObject;
                SpawnKeys keyReset = resetObjPos.gameObject.GetComponent<SpawnKeys>();
                CollectionCounter keyCounter = resetKeys.gameObject.GetComponent<CollectionCounter>();
                keyReset.keysSpawned = 0;
                keyCounter.keyCounter = 0;
                timerScript.ResetTime();

                resetAmmo.AddAmmo(25);
                resetAmmo.AddRockets(2);
                resetAmmo.AddLaser(15);
            }
            else if (hitCollider.gameObject.CompareTag("ThirdObjective"))
            {
                resetObjPos = hitCollider.gameObject;
                PayloadMove payloadScript = resetObjPos.gameObject.GetComponent<PayloadMove>();

                if (resetFirstPos != null)
                {
                    //move payload back in position

                    resetObjPos.transform.position = resetFirstPos.transform.position;
                }
                //reset the bools that move the payload

                payloadScript.firstCheckpoint = false;
                payloadScript.secondCheckpoint = true;
                payloadScript.thirdCheckpoint = false;
                payloadScript.fourthCheckpoint = false;
                payloadScript.fifthCheckpoint = false;
                payloadScript.sixthCheckpoint = false;
                payloadScript.seventhCheckpoint = false;
                payloadScript.eighthCheckpoint = false;
               

                PayloadHealth payloadHealthScript = resetObjPos.gameObject.GetComponent<PayloadHealth>();

                payloadHealthScript.AddHealth(10);
                resetAmmo.AddAmmo(25);
                resetAmmo.AddRockets(2);
                resetAmmo.AddLaser(15);
            }
        }
    }


    IEnumerator RoomResetUI()
    {
        //Add room reset UI here and some sound
        playerDeathUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        playerDeathUI.SetActive(false);

        //Turn it off here

    }





    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
