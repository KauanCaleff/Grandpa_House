using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : MonoBehaviour, IInteractable
{
    [SerializeField] private Item itemData;
    [SerializeField] private Inventario inventarioitem;

    public void IInteract()
    {
        if (itemData.name == "Lupa")
        {
            inventarioitem.AddItem(itemData);
            Debug.Log("oi");

        }
    }
}
