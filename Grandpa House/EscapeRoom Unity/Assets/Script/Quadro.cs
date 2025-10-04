using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Quadro : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;
    public PlayerInteractionsManager playerInteractionsManager;
    public Martelo martelo;
    public StudioEventEmitter emitter;

    public void IInteract()
    {
        if(scriptableObject.name == "Quadro" && playerInteractionsManager.interagindo)
        {
            InteragirMartelo();
            emitter.Play();
        } 
    }
    public void InteragirMartelo()
    {
        if(martelo.equipped ==true)
        {
            Destroy(gameObject);

        }
        else
        {
            return;
        }

    }
}
