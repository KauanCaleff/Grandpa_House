using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, camera;
    
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;

    void Start()
    {
        if(!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if(equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) PickUp();

        if(equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    void PickUp()
    {
        equipped = true;

        rb.isKinematic = true;
        coll.isTrigger = true;

        transform.SetParent(camera);
        transform.localPosition = new Vector3(0.598f, -0.188f, 0.653f); // ajuste conforme necessário
        transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
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


}
