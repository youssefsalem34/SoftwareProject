using UnityEngine;
using UnityEngine.EventSystems;
public class HoverClient : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    [SerializeField] private GameObject hoverClient;
    //[SerializeField] private GameObject hoverClient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Add your hover logic here, e.g., change color, highlight, etc.
        hoverClient.SetActive(true);
    }

    // Called when the pointer exits the object
    public void OnPointerExit(PointerEventData eventData)
    {
        // Add your hover exit logic here, e.g., reset color, unhighlight, etc.
        hoverClient.SetActive(false);
    }
}
