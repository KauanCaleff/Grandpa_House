using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{
    public void IInteract()
    {
        Debug.Log("Oi");
    }
}
