using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : MonoBehaviour, IInteractable
{
    [SerializeField] private ScriptableObject scriptableObject;

    public void IInteract()
    {
        if (scriptableObject.name == "Lupa")
        {
            Debug.Log("oi");
        }
    }
}
