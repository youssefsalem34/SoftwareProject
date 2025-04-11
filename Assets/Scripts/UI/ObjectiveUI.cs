using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private GameObject firstObjText;
    [SerializeField] private GameObject secondObjText;
    [SerializeField] private GameObject thirdObjText;
    [SerializeField] private TMP_Text enemyCounterUI;
    [SerializeField] private TMP_Text keyCounterUI;

  // [SerializeField] private GameObject firstObj;
    //[SerializeField] private GameObject secondObj;
    //[SerializeField] private GameObject thirdObj;
    [SerializeField] private float radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SearchForObjective();
       // TurnOffOldUI();
    }

    //TEMPORARY SOLUTION FOR THE OBJECTIVE TEXT UI
    void SearchForObjective()
    {
        Vector3 position = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        firstObjText.SetActive(false);
        secondObjText.SetActive(false);
        thirdObjText.SetActive(false);
        foreach (Collider hitCollider in hitColliders)
        {
            // Debug.Log(hitCollider);
            if (hitCollider.gameObject.CompareTag("FirstObjective"))
            {
                firstObjText.SetActive(true);
                EliminateEnemies enemyScript = hitCollider.gameObject.GetComponent<EliminateEnemies>();
                enemyCounterUI.text = enemyScript.numberOfEnemiesKilled.ToString();
                break; // Only show the first detected objective UI
            }
            else if (hitCollider.gameObject.CompareTag("SecondObjective"))
            {
                secondObjText.SetActive(true);
                CollectionCounter keyScript = hitCollider.gameObject.GetComponent<CollectionCounter>();
                keyCounterUI.text = keyScript.keyCounter.ToString();
                break;
            }
            else if (hitCollider.gameObject.CompareTag("ThirdObjective"))
            {
                thirdObjText.SetActive(true);
                break;
            }
        }
    }

    void TurnOffOldUI()
    {
        if(firstObjText.activeSelf)
        {
            secondObjText.SetActive(false);
            thirdObjText.SetActive(false);
        }
        else if (secondObjText.activeSelf)
        {
            firstObjText.SetActive(false);
            thirdObjText.SetActive(false);
        }
        else if (thirdObjText.activeSelf)
        {
            secondObjText.SetActive(false);
            firstObjText.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
