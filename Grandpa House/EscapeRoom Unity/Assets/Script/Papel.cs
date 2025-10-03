using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papel : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;
    public GameObject PapelPImage;
    public GameObject PapelGImage;
    public Lupa Lupa;
    public bool interagindo;
    public void IInteract()
    {
        if(scriptableObject.name == "Papel")
        {
  
            if (Lupa.LupaOn == false)
            {
                PapelPImage.SetActive(true);
                    Debug.Log("PAPELLLLLL");
                }
                else
                {
                    PapelGImage.SetActive(true);
                }
            
        }
    }
}
