using UnityEngine;
using UnityEngine.EventSystems;
public class HoverCreate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    [SerializeField] private GameObject hoverCreate;
    //[SerializeField] private GameObject hoverClient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Add your hover logic here, e.g., change color, highlight, etc.
        hoverCreate.SetActive(true);
    }

    // Called when the pointer exits the object
    public void OnPointerExit(PointerEventData eventData)
    {
        // Add your hover exit logic here, e.g., reset color, unhighlight, etc.
        hoverCreate.SetActive(false);
    }
}
