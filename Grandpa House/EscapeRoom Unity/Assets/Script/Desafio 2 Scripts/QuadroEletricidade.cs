using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadroEletricidade : MonoBehaviour, IInteractable
{
    [SerializeField] private ScriptableObject scriptableObject;
    [SerializeField] private GameObject EletricPanel;
    public PlayerInteractionsManager playerInteractionsManager;

    public bool interagivel = false;
    public bool quadroAberto;
    public Mouse playerMouse;

    public void IInteract()
    {
        EletricPanel.SetActive(true);
        if (playerMouse != null){
            playerMouse.LockMouse();
        }
    }

    public void NaoInteragir()
    {
        EletricPanel.SetActive(false);
        quadroAberto = false;
        if (playerMouse != null){
            playerMouse.UnlockMouse();
        }
    }
}

