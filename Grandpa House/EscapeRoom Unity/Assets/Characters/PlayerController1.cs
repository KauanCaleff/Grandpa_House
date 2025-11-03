using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    [Header("Movimentação")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f;

    [Header("Verificação de chão")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    private bool isGrounded;

    [Header("Animação")]
    public Animator animator;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector2 moveInput;
    private bool isRunning = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Verifica se está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Direção do movimento
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        // Velocidade (andar ou correr)
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Atualiza a velocidade pro Animator
        animator.SetFloat("Speed", move.magnitude * (isRunning ? 2f : 1f));
        animator.SetBool("isGrounded", isGrounded);

        // Gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Input do movimento (novo Input System)
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Input de pulo
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }
    }

    // Input de correr (Shift)
    //public void OnRun(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //        isRunning = true;
    //    else if (context.canceled)
    //        isRunning = false;
    //}
}