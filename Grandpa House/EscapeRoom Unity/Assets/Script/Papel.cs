using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papel : MonoBehaviour, IInteractable
{
    [SerializeField]private ScriptableObject scriptableObject;
    public GameObject PapelPImage;

    public void IInteract()
    {
        if(scriptableObject.name == "Papel")
        {
            PapelPImage.SetActive(true);
            //Destroy(gameObject);
        } 
    }
}
