using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : MonoBehaviour, IInteractable
{
    [SerializeField] private Item itemData;
    public bool LupaOn = false;

    public void IInteract()
    {
        if (itemData.name == "Lupa")
        {
            LupaOn = true;
            Debug.Log("oi");

        }
    }
}
