using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int layer1 = LayerMask.NameToLayer("whatIsGround");
        int layer2 = LayerMask.NameToLayer("Shield");

        Physics.IgnoreLayerCollision(layer1, layer2, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
