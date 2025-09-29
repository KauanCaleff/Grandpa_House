using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadro : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;

    public void IInteract()
    {
        if(scriptableObject.name == "Quadro")
        {
            Destroy(gameObject);
        } 
    }
}
