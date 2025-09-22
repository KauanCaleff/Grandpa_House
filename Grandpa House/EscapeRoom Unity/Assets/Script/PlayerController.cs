using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private IInteractable interactableInstance;
    public CharacterController character;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private float horizontalInput;
    private float verticalInput;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    bool isGrounded;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
       
    }
   
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

        character.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);

    }

    public void OnMoveEvent(InputAction.CallbackContext value)
    {
        horizontalInput = value.ReadValue<Vector2>().x;
        verticalInput = value.ReadValue<Vector2>().y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    public void OnTryInteract(InputAction.CallbackContext value)
    {
        if(interactableInstance != null)
        {
            interactableInstance.InteractableLogic();
        }
    }
    public void SetIInteractable(IInteractable interactable)
    {
        interactableInstance = interactable;
    }
    public void ClearIInstance()
    {
        interactableInstance = null;
    }
}
