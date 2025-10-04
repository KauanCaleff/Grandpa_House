using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class Martelo : MonoBehaviour, IInteractable
{
    
    [SerializeField] private ScriptableObject scriptableObject; 

    public Rigidbody rb;       // Referência ao Rigidbody do item 
    public BoxCollider coll;   // Collider do item
    public Transform player;   // Referência ao player
    public Transform camera;   // Referência à câmera do player
    
    public float pickUpRange;         // Alcance para pegar o item
    public float dropForwardForce;    // Força aplicada para frente ao soltar
    public float dropUpwardForce;     // Força aplicada para cima ao soltar

    public bool equipped; // Indica se o item está equipado

    public StudioEventEmitter emitter; // Emissor de som 

    void Start()
    {
        if (!equipped) // Se não está equipado no início
        {
            rb.isKinematic = false;   
            coll.isTrigger = false;   
        }

        if (equipped) // Se já começa equipado
        {
            rb.isKinematic = true;    
            coll.isTrigger = true;   
        }
    }

    public void IInteract()
    {
        if (scriptableObject.name == "Martelo") 
        {
            if (!equipped) // Se não está equipado
                PickUp();  // Equipa o item
            emitter.Play(); // Toca o som
        } else
        {
            Drop(); // Caso não seja o martelo, solta
        }
    }

    void PickUp()
    {
        equipped = true; // Marca como equipado

        rb.isKinematic = true;   
        coll.isTrigger = true;   

        transform.SetParent(camera); // Torna o item filho da câmera (se move junto)
        transform.localPosition = new Vector3(0.598f, -0.188f, 0.653f); // Ajusta posição na mão
        transform.localRotation = Quaternion.Euler(360f, 0f, 0f);       // Ajusta rotação na mão
    }

    void Drop()
    {
        equipped = false; // Marca como não equipado

        transform.SetParent(null); // Remove vínculo com a câmera

        rb.isKinematic = false; // Física ligada novamente
        coll.isTrigger = false; // Collider volta a ser sólido

        rb.velocity = player.GetComponent<PlayerController>().velocity; // Dá a mesma velocidade do player ao soltar

        rb.AddForce(camera.forward * dropForwardForce, ForceMode.Impulse); // Adiciona força para frente
        rb.AddForce(camera.up * dropUpwardForce, ForceMode.Impulse);       // Adiciona força para cima
    }

    public void OnDrop(InputAction.CallbackContext value)
    {
        Drop(); // Quando o input de "drop" é acionado, solta o item
    }
}

