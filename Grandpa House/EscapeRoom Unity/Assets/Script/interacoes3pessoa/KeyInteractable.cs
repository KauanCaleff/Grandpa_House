using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class KeyInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Item itemData;    

    public Transform player;                 
    public Transform camera;                  

    [SerializeField] private Vector3 handLocalPosition = new Vector3(0.05f, 0.0f, 0.0f);
    [SerializeField] private Vector3 handLocalEulerAngles = new Vector3(0f, 0f, 90f);

    public bool equipped;

    private Rigidbody rb;
    private Collider coll;
    private ObjectPickup playerPickup;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    private void Start()
    {
        rb.isKinematic = equipped;
        coll.isTrigger = equipped;

        if (player != null)
        {
            playerPickup = player.GetComponent<ObjectPickup>();
        }
    }

    public void IInteract()
    {
        Debug.Log("[KeyInteractable] IInteract chamado em: " + gameObject.name);

        if (itemData != null && !itemData.grabbable)
            return;

        if (!equipped)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        Debug.Log("[KeyInteractable] Pegando a chave.");

        if (player != null)
        {
            var controller = player.GetComponent<PlayerController1>();
            if (controller != null)
            {
                controller.PlayPickupAnimation();
            }
        }

        equipped = true;

        rb.isKinematic = true;
        coll.isTrigger = true;

  
        if (playerPickup == null && player != null)
            playerPickup = player.GetComponent<ObjectPickup>();

        if (playerPickup != null)
        {
            playerPickup.AttachToRightHand(transform, handLocalPosition, handLocalEulerAngles);
        }
        else
        {
            transform.SetParent(camera);
            transform.localPosition = new Vector3(0.3f, -0.2f, 0.6f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (playerPickup != null)
            playerPickup.SetHasKey(true);
    }
}