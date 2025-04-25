using System.Globalization;
using Unity.Netcode;
using UnityEngine;
using Unity.Netcode;

public class SwitchBetweenWeapons : NetworkBehaviour
{
    [SerializeField] private GameObject weapon1;
    [SerializeField] private GameObject weapon2;
    [SerializeField] private GameObject weapon3;
    [SerializeField] private GameObject weapon4;
    [SerializeField] private GameObject weapon1UI;
    [SerializeField] private GameObject weapon1UISecond;
    [SerializeField] private GameObject weapon2UI;
    [SerializeField] private GameObject weapon2UISecond;
    [SerializeField] private GameObject weapon3UI;
    [SerializeField] private GameObject weapon3UISecond;
    [SerializeField] private GameObject weapon4UI;
    [SerializeField] private GameObject weapon4UISecond;
    [SerializeField] private GameObject wep1UI;
    [SerializeField] private GameObject wep2UI;
    [SerializeField] private GameObject wep3UI;
    [SerializeField] private GameObject wep1Glow;
    [SerializeField] private GameObject wep2Glow;
    [SerializeField] private GameObject wep3Glow;
    [SerializeField] private GameObject wep4Glow;
  //  [SerializeField] private GameObject wep4UI;



    public bool upgradeTime;
    public bool wep1Unlocked;
    public bool wep2Unlocked;
    public bool wep3Unlocked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //weapon1UI.SetActive(false);
        //weapon1UISecond.SetActive(false);
        //weapon2UI.SetActive(false);
        //weapon2UISecond.SetActive(false);
        //weapon3UI.SetActive(false);
        //weapon3UISecond.SetActive(false);
        //weapon4UI.SetActive(false);
        //weapon4UISecond.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!IsOwner)
        {
            return;
        }

        if (IsLocalPlayer)
        {
            if (upgradeTime == true)
            {

                //wep1UI.SetActive(true);
                //wep2UI.SetActive(true);
                //wep3UI.SetActive(true);
                CheckWeaponUnlocks();

                if (Input.GetKeyDown(KeyCode.Alpha1) && !wep1Unlocked)
                {
                    wep1UI.SetActive(false);
                    wep2UI.SetActive(false);
                    wep3UI.SetActive(false);
                    // wep4UI.SetActive(false);
                    wep1Unlocked = true;
                    upgradeTime = false;

                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && !wep2Unlocked)
                {
                    wep1UI.SetActive(false);
                    wep2UI.SetActive(false);
                    wep3UI.SetActive(false);
                    // wep4UI.SetActive(false);
                    wep2Unlocked = true;
                    upgradeTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) && !wep3Unlocked)
                {
                    wep1UI.SetActive(false);
                    wep2UI.SetActive(false);
                    wep3UI.SetActive(false);
                    // wep4UI.SetActive(false);
                    wep3Unlocked = true;
                    upgradeTime = false;
                }
            }
        }
    

        if (wep1Unlocked)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weapon1.SetActive(true);
                weapon2.SetActive(false);
                weapon3.SetActive(false);
                weapon4.SetActive(false);
                weapon1UI.SetActive(true);
                weapon1UISecond.SetActive(true);
                weapon2UI.SetActive(false);
                weapon2UISecond.SetActive(false);
                weapon3UI.SetActive(false);
                weapon3UISecond.SetActive(false);

                weapon4UI.SetActive(false);
                weapon4UISecond.SetActive(false);
                wep1Glow.SetActive(true);
                wep2Glow.SetActive(false);
                wep3Glow.SetActive(false);
                wep4Glow.SetActive(false);



            }
        }
      
        if (wep2Unlocked)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weapon1.SetActive(false);
                weapon2.SetActive(true);
                weapon3.SetActive(false);
                weapon4.SetActive(false);
                weapon1UI.SetActive(false);
                weapon1UISecond.SetActive(false);
                weapon2UI.SetActive(true);
                weapon2UISecond.SetActive(true);
                weapon3UI.SetActive(false);
                weapon3UISecond.SetActive(false);

                weapon4UI.SetActive(false);
                weapon4UISecond.SetActive(false);
                wep1Glow.SetActive(false);
                wep2Glow.SetActive(true);
                wep3Glow.SetActive(false);
                wep4Glow.SetActive(false);



            }
        }
      
        if (wep3Unlocked)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weapon1.SetActive(false);
                weapon2.SetActive(false);
                weapon3.SetActive(true);
                weapon4.SetActive(false);
                weapon1UI.SetActive(false);
                weapon1UISecond.SetActive(false);
                weapon2UI.SetActive(false);
                weapon2UISecond.SetActive(false);
                weapon3UI.SetActive(true);
                weapon3UISecond.SetActive(true);

                weapon4UI.SetActive(false);
                weapon4UISecond.SetActive(false);
                wep1Glow.SetActive(false);
                wep2Glow.SetActive(false);
                wep3Glow.SetActive(true);
                wep4Glow.SetActive(false);





            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
            weapon4.SetActive(true);
            weapon1UI.SetActive(false);
            weapon1UISecond.SetActive(false);
            weapon2UI.SetActive(false);
            weapon2UISecond.SetActive(false);
            weapon3UI.SetActive(false);
            weapon3UISecond.SetActive(false);
            weapon4UI.SetActive(true);
            weapon4UISecond.SetActive(true);

            wep1Glow.SetActive(false);
            wep2Glow.SetActive(false);
            wep3Glow.SetActive(false);
            wep4Glow.SetActive(true);





        }

    }


    void CheckWeaponUnlocks()
    {

        wep1UI.SetActive(true);
        wep2UI.SetActive(true);
        wep3UI.SetActive(true);

        if (wep1Unlocked)
            wep1UI.SetActive(false);

        if (wep2Unlocked)
            wep2UI.SetActive(false);

        if (wep3Unlocked)
            wep3UI.SetActive(false);


    }
}
