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
        if (!equipped)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if (player != null)
        {
            var controller = player.GetComponent<PlayerController1>();
            controller.PlayPickupAnimation();
        }

        equipped = true;

        rb.isKinematic = true;
        coll.isTrigger = true;

        playerPickup = player.GetComponent<ObjectPickup>();

        playerPickup.AttachToRightHand(transform, handLocalPosition, handLocalEulerAngles);
        
        playerPickup.SetHasKey(true);
    }
}