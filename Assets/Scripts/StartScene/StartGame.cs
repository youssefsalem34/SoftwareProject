using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]private GameObject currrentCanvas;
    [SerializeField]private GameObject mainCanvas;
    [SerializeField]private GameObject mainUI;
    [SerializeField]private GameObject mainCamera;
    [SerializeField]private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCanvas = Resources.Load("MainUI") as GameObject;
        mainUI = Instantiate(mainCanvas, this.transform.position, Quaternion.identity);
        mainUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            currrentCanvas.SetActive(false);
            mainCamera.SetActive(false);
             mainUI.SetActive(true);
            
       }
        else if(player == null)
        {
            Debug.Log("No Player Yet");
        }
    }
}
