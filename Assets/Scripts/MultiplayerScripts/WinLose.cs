using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{

    public bool victory;
    public bool defeat;
    
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject winUI;
    [SerializeField] public GameObject loseUI;
    [SerializeField] private GameObject otherTeam;
    [SerializeField] private WinLose winLoseScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winLoseScript = otherTeam.GetComponent<WinLose>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            GameObject mainUI = player.transform.GetChild(5).gameObject;

            if (mainUI != null)
            {
                // Find "Win" and "Lose" GameObjects even if they are inactive
                winUI = mainUI.transform.GetChild(19).gameObject;
                loseUI = mainUI.transform.GetChild(18).gameObject;
            }
            //Transform uiTransform = transform.Find("MainUI");
            //if (uiTransform != null)
            //{
            //    Transform imageTransform = uiTransform.GetComponentInChildren<Transform>(true);

            //    if (imageTransform != null && imageTransform.name == "Win")
            //    {
            //        winUI = imageTransform.gameObject;
            //    }
            //}
        }


        if (victory)
        {
            winUI.gameObject.SetActive(true);
        }
        else if (defeat)
        {
            loseUI.gameObject.SetActive(true);
        }

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            victory = true;
            if(winLoseScript != null)
            {
                winLoseScript.defeat = true;
            }
           
        }
    }
}
