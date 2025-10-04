using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class Lupa : MonoBehaviour, IInteractable
{
    [SerializeField] private ScriptableObject scriptableObject;

    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, camera;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;

    private Vector3 initialPosition;

    public StudioEventEmitter emitter;

    void Start()
    {
        initialPosition = transform.position;
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }



    public void IInteract()
    {
        if (scriptableObject.name == "Lupa")
        {
            if (!equipped){
                PickUp();
                emitter.Play();
            }
            else{
                Drop();
            }
        }
    }

    void PickUp()
    {
        equipped = true;

        rb.isKinematic = true;
        coll.isTrigger = true;

        transform.SetParent(camera);
        transform.localPosition = new Vector3(0.598f, -0.188f, 0.653f);
        transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
    }

    void Drop()
    {
        equipped = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(camera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(camera.up * dropUpwardForce, ForceMode.Impulse);
    }

    public void OnDrop(InputAction.CallbackContext value)
    {
        Drop();
    }
}
