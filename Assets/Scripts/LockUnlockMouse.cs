using UnityEngine;

public class MouseLockToggle : MonoBehaviour
{
    private bool isLocked = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isLocked = !isLocked;

            if (isLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
