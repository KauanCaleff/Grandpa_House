using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;

    public void IInteract()
    {
        if(scriptableObject.name == "Caixa")
        {
            Destroy(gameObject);
        } 
    }
}
