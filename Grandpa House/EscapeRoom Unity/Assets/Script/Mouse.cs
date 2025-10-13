using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse : MonoBehaviour
{
    public float Sensitivity = 100f;
    float xRotation = 0f;
    public Transform Camera;
    private Vector2 Inputmouse;
    public bool isLocked = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LockMouse();
    }

// Update is called once per frame
    void Update()
    {
        float mouseX = Inputmouse.x * Sensitivity * Time.deltaTime;
        float mouseY = Inputmouse.y * Sensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    public void OnLookEvent(InputAction.CallbackContext context)
    {
         Inputmouse = context.ReadValue<Vector2>();
        
    }

    public void LockMouse()
    {
        isLocked = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnlockMouse()
    {
        isLocked = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
