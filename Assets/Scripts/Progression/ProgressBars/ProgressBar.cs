using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public GameObject progressBar;
    private Slider bar1Slider;
    [SerializeField] private GameObject progressBar2;
    private Slider bar2Slider;
    public GameObject P1;
    public GameObject P2;
    [SerializeField]private AttributeManager roomP1;
    [SerializeField]private AttributeManager roomP2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

       // 
       //  bar2Slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(P1 != null)
        {
            roomP1 = P1.GetComponent<AttributeManager>();
            ControlBars();
        }
        else
        {

        }

        if(P2 != null)
        {
            roomP2 = P2.GetComponent<AttributeManager>();
            ControlBars2();
        }
        else
        {

        }
        // progressBar = GameObject.FindWithTag("progressbar1");
        //progressBar2 = GameObject.FindWithTag("progressbar2");
        if (progressBar != null)
        {
            bar1Slider = progressBar.GetComponent<Slider>();
           
        }
        if (progressBar2 != null)
        {
            bar2Slider = progressBar2.GetComponent<Slider>();
           
        }
       
        
    }
    void ControlBars()
    {
        if(roomP1.RoomCheck() == 1)
        {
            bar1Slider.value = 1;
        }
        else if(roomP1.RoomCheck()== 2)
        {
            bar1Slider.value = 2;
        }
        else if (roomP1.RoomCheck() == 3)
        {
            bar1Slider.value = 3;
        }
        else if (roomP1.RoomCheck() == 4)
        {
            bar1Slider.value = 4;
        }
        else if (roomP1.RoomCheck() == 5)
        {
            bar1Slider.value = 5;
        }
    }
    void ControlBars2()
    {
        if (roomP2.RoomCheck() == 1)
        {
            bar2Slider.value = 1;
        }
        else if (roomP2.RoomCheck() == 2)
        {
            bar2Slider.value = 2;
        }
        else if (roomP2.RoomCheck() == 3)
        {
            bar2Slider.value = 3;
        }
        else if (roomP2.RoomCheck() == 4)
        {
            bar2Slider.value = 4;
        }
        else if (roomP2.RoomCheck() == 5)
        {
            bar2Slider.value = 5;
        }
    }
}
