using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadro : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;
    public PlayerInteractionsManager playerInteractionsManager;
    public Martelo martelo;

    public void IInteract()
    {
        if(scriptableObject.name == "Quadro" && playerInteractionsManager.interagindo)
        {
            InteragirMartelo();
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
