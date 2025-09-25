using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/*interface IInteractable
{
    public void IInteract();
}*/
public class PlayerInteractionsManager : MonoBehaviour
{
    public Transform InteractionsSouce;
    public float InteractionRange;
    public InputActionReference interactionInputAction;

    private void OnEnable()
    {
        interactionInputAction.action.performed += Interact;
    }

    private void OnDisable()
    {
        interactionInputAction.action.performed -= Interact;
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        Ray playerAim = new Ray(InteractionsSouce.position, InteractionsSouce.forward);
        if(Physics.Raycast(playerAim, out RaycastHit hitinfo, InteractionRange))
        {
            if(hitinfo.collider.TryGetComponent(out IInteractable interactableObj))
            {
                interactableObj.IInteract();
            }
        }
    }
}
