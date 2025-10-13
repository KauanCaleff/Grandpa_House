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

    public void IInteract()
    {
        EletricPanel.SetActive(true);
    }

    public void NaoInteragir()
    {
        EletricPanel.SetActive(false);
        quadroAberto = false;
    }
}

