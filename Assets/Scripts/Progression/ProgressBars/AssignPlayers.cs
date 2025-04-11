using UnityEngine;

public class AssignPlayers : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] GameObject victory;
    [SerializeField] WinLose winloseScript;
    [SerializeField] GameObject UI;
    [SerializeField] ProgressBar uiScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI = GameObject.Find("CombinedUI");
        uiScript = UI.GetComponent<ProgressBar>();
        winloseScript = victory.GetComponent<WinLose>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayers();
    }

    void DetectPlayers()
    {
        Vector3 position = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            // Do something with each hit object
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                uiScript.P1 = hitCollider.gameObject;
                winloseScript.player = hitCollider.gameObject;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
