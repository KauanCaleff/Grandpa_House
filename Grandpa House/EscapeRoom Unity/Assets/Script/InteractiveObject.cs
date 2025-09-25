using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{
    public Item item;
    public void IInteract()
    {
        Debug.Log("Oi");
    }
}
