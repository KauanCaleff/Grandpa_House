using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadro : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;
    [SerializeField] private Item itemData;
    [SerializeField] private Inventario inventarioitem;

    public void IInteract()
    {
        if(scriptableObject.name == "Quadro" && inventarioitem.name == "Martelo")
        {
            Destroy(gameObject);
        } 
    }
}
