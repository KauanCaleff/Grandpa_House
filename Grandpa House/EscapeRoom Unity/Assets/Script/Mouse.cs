using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse : MonoBehaviour
{
    [Header("Sensibilidade do Mouse")]
    public float sensitivityX = 200f;
    public float sensitivityY = 150f;

    [Header("Referências")]
    public Transform playerBody;   // Player para rotacionar no eixo Y
    public Transform cameraPivot;  // Um empty atrás da cabeça onde a câmera fica

    private Vector2 mouseInput;
    private float verticalRotation = 0f;

    public bool isLocked = false;

    void Start()
    {
        UnlockMouse();
    }

    void Update()
    {
        if (isLocked) return;

        float mouseX = mouseInput.x * sensitivityX * Time.deltaTime;
        float mouseY = mouseInput.y * sensitivityY * Time.deltaTime;

        // Rotação horizontal → gira o PLAYER
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotação vertical → gira o PIVOT da câmera
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -45f, 60f); // Ajuste conforme desejar

        cameraPivot.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    public void OnLookEvent(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
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
