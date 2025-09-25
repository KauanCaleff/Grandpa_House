using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{
    /// EXEMPLOOOOOO/// USAR DE MODELO NO SCRIPT DO OBJETO
    [SerializeField]private ScriptableObject scriptableObject;

    public void IInteract()
    {
        if(scriptableObject.name == "Caixa")
        {
            Destroy(gameObject);
        } 
    }
}
