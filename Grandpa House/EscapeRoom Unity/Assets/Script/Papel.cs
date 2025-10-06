using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Papel : MonoBehaviour, IInteractable
{
    [SerializeField] private ScriptableObject scriptableObject;
    public GameObject PapelPImage;
    public GameObject PapelGImage;
    public Lupa Lupa;
    public PlayerInteractionsManager playerInteractionsManager;
    public bool PapelAberto;
    public StudioEventEmitter emitter;

    public bool interagivel = false;

    public void IInteract()
    {
        if (!interagivel) return;

        if (scriptableObject.name == "Papel" && playerInteractionsManager.interagindo)
        {
            InteragirLupa();
        }

    }
    void Update()
    {
        if (PapelAberto && !playerInteractionsManager.interagindo)
        {
            NaoInteragir();
        }
    }
    public void InteragirLupa()
    {
        if (Lupa.equipped == false)
        {
            PapelPImage.SetActive(true);
            emitter.Play();
        }
        else
        {
            PapelGImage.SetActive(true);
            emitter.Play();
        }
        PapelAberto = true;
    }
    public void NaoInteragir()
    {
        PapelGImage.SetActive(false);
        PapelPImage.SetActive(false);
        PapelAberto = false;
    }
    
    public void LiberarInteracao()
    {
        interagivel = true;
    }
}
