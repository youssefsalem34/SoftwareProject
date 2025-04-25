using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Ammo : NetworkBehaviour
{
    [SerializeField] private int weapon1;
    [SerializeField] private int weapon2;
    [SerializeField] private float weapon3;
    [SerializeField] private int weapon4;
    [SerializeField] private TMP_Text weapon1UI;
    [SerializeField] private GameObject weapon1Object;
    [SerializeField] private TMP_Text weapon2UI;
    [SerializeField] private GameObject weapon2Object;
    [SerializeField] private TMP_Text weapon3UI;
    [SerializeField] private GameObject weapon3Object;
    [SerializeField] private TMP_Text weapon4UI;
    [SerializeField] private GameObject weapon4Object;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    

       
        if (weapon1Object != null)
        {
            weapon1UI = weapon1Object.GetComponent<TMP_Text>();
        }
        if (weapon2Object != null)
        {
            weapon2UI = weapon2Object.GetComponent<TMP_Text>();
        }

        if (weapon3Object != null)
        {
            weapon3UI = weapon3Object.GetComponent<TMP_Text>();
        }

        if (weapon4Object != null)
        {
            weapon4UI = weapon4Object.GetComponent<TMP_Text>();
        }

    }

    // Update is called once per frame
    void Update()
    {
       // ammoUI.SetText(rocketCount.ToString());
      weapon1UI.SetText(weapon1.ToString());
      weapon2UI.SetText(weapon2.ToString());
      weapon3UI.SetText(weapon3.ToString());
      weapon4UI.SetText(weapon4.ToString());
       
    }





    public int CheckBullets()
    {
        return weapon1;
    }

    public int DeducAmmo(int m)
    {
        weapon1 -= m;
        return weapon1;
    }
    public int AddAmmo(int m)
    {
        weapon1 += m;
        return weapon1;
    }
    public int CheckRockets()
    {
        return weapon2;
    }
  
    public int DeducRocket(int m)
    {
        weapon2 -= m;
        return weapon2;
    }
    public int AddRockets(int m)
    {
        weapon2 += m;
        return weapon2;
    }

    public float DeducLaser(float m)
    {
        weapon3 -= m;
        return weapon3;
    }
    public float AddLaser(float m)
    {
        weapon3 += m;
        return weapon3;
    }
    public float CheckLaser()
    {
        return weapon3;
    }

    public int DeducBlaster (int m)
    {
        weapon4 -= m;
        return weapon4;
    }
    public int CheckBlaster()
    {
        return weapon4;
    }
}
