using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
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
    public Vector3 velocity;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
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

        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

    }

    public void OnMoveEvent(InputAction.CallbackContext value)
    {
        horizontalInput = value.ReadValue<Vector2>().x;
        verticalInput = value.ReadValue<Vector2>().y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        animator.SetTrigger("Jump");
    }
    public void OnTryInteract(InputAction.CallbackContext value)
    {
        if(interactableInstance != null)
        {
            interactableInstance.IInteract();
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

    public void PlayPickupAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Pickup");
        }
    }

    public void PlayOpenDoorAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("OpenDoor");
        }
    }
}
