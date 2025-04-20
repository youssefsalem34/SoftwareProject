using UnityEngine;

public class BeginGame : MonoBehaviour
{
    [SerializeField] private GameObject uI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // uI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
