using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papel : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;
    public GameObject PapelPImage;
    public GameObject PapelGImage;
    public Lupa Lupa;
    public PlayerInteractionsManager playerInteractionsManager;
    public bool PapelAberto;
    public void IInteract()
    {
        if(scriptableObject.name == "Papel" && playerInteractionsManager.interagindo)
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
        if(Lupa.equipped == false)
        {
            PapelPImage.SetActive(true);

        }
        else
        {
            PapelGImage.SetActive(true);
        }
        PapelAberto = true;
    }
    public void NaoInteragir()
    {
        PapelGImage.SetActive(false);
        PapelPImage.SetActive(false);
        PapelAberto = false;
    }
}
