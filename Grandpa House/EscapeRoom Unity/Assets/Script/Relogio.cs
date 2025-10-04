using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Relogio : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;
    public StudioEventEmitter emitter;

    public void IInteract()
    {
        if(scriptableObject.name == "Relogio")
        {
            emitter.Play();
        } 
    }
}
