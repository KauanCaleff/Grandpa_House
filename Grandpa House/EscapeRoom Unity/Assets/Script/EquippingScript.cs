using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquippingScript : MonoBehaviour
{
    public GameObject Lanterna;
    public GameObject Ferramenta;


    public void OnEquipLantEvent(InputAction.CallbackContext context)
    {
        EquipLant();
    }

    public void OnEquipFerEvent(InputAction.CallbackContext context)
    {
        EquipFer();
    }

    void EquipLant()
    {
        Lanterna.SetActive(true);
        Ferramenta.SetActive(false);
    } 

    void EquipFer()
    {
        Lanterna.SetActive(false);
        Ferramenta.SetActive(true);
    }
}
