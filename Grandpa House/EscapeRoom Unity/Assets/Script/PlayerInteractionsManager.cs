using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionsManager : MonoBehaviour
{
    public Transform InteractionsSouce;
    public float InteractionRange;
    public bool interagindo;
    public InputActionReference interactionInputAction;

    private void OnEnable()
    {
        interactionInputAction.action.performed += Interact;
    }

    private void OnDisable()
    {
        interactionInputAction.action.performed -= Interact;
    }
    private void Update()
    {
        CheckInteract();
    }
    private void CheckInteract()
    {
        Ray playerAim = new Ray(InteractionsSouce.position, InteractionsSouce.forward);
        if (Physics.Raycast(playerAim, out RaycastHit hitinfo, InteractionRange))
        {
            IInteractable interactableObj = hitinfo.collider.GetComponentInParent<IInteractable>();

            if (interactableObj != null)
            {
                Uimanager.Instance.SetHandCursor(true); 
                interagindo = true;
                return;
            }
        }

        Uimanager.Instance.SetHandCursor(false);
        Uimanager.Instance.SetInteragir(false);
        interagindo = false;
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        Ray playerAim = new Ray(InteractionsSouce.position, InteractionsSouce.forward);
        if (Physics.Raycast(playerAim, out RaycastHit hitinfo, InteractionRange))
        {
            IInteractable interactableObj = hitinfo.collider.GetComponentInParent<IInteractable>();

            if (interactableObj != null)
            {
                interactableObj.IInteract();
            }
        }
    }
}
