using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadroEletricidade : MonoBehaviour, IInteractable
{
    [SerializeField] private ScriptableObject scriptableObject;
    [SerializeField] private GameObject ImageKeypad;

    public void IInteract()
    {
        ImageKeypad.SetActive(true);
    }

}

