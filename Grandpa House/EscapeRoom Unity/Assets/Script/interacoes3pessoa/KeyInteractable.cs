using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class KeyInteractable : MonoBehaviour, IInteractable
{
    [Header("Dados do Item")]
    [SerializeField] private Item itemData;    // ScriptableObject "Key (Item)"

    [Header("Referências")]
    public Transform player;                  // arrasta o Player
    public Transform camera;                  // arrasta a Camera (usado só como fallback)

    [Header("Posição na mão")]
    [SerializeField] private Vector3 handLocalPosition = new Vector3(0.05f, 0.0f, 0.0f);
    [SerializeField] private Vector3 handLocalEulerAngles = new Vector3(0f, 0f, 90f);

    [Header("Forças de drop")]
    public float dropForwardForce = 2f;
    public float dropUpwardForce = 1f;

    [Header("Estado")]
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
        else
        {
            Drop();
        }
    }

    private void PickUp()
    {
        Debug.Log("[KeyInteractable] Pegando a chave.");

        equipped = true;

        rb.isKinematic = true;
        coll.isTrigger = true;

        // ✅ Preferência: colocar na mão
        if (playerPickup == null && player != null)
            playerPickup = player.GetComponent<ObjectPickup>();

        if (playerPickup != null)
        {
            playerPickup.AttachToRightHand(transform, handLocalPosition, handLocalEulerAngles);
        }
        else
        {
            // Fallback: cola na câmera se por algum motivo não tiver ObjectPickup
            transform.SetParent(camera);
            transform.localPosition = new Vector3(0.3f, -0.2f, 0.6f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (playerPickup != null)
            playerPickup.SetHasKey(true);
    }

    private void Drop()
    {
        Debug.Log("[KeyInteractable] Dropando a chave.");

        equipped = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        Vector3 vel = Vector3.zero;
        if (player != null)
        {
            var pc1 = player.GetComponent<PlayerController1>();
            if (pc1 != null)
                vel = pc1.velocity;
        }

        rb.velocity = vel;

        rb.AddForce(camera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(camera.up * dropUpwardForce, ForceMode.Impulse);

        if (playerPickup != null)
            playerPickup.SetHasKey(false);
    }

    public void OnDrop(InputAction.CallbackContext value)
    {
        if (equipped)
            Drop();
    }
}