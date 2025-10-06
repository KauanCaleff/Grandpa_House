using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trig : MonoBehaviour
{
    public GameObject obj;
    public GameObject botoes;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            obj.SetActive(true);
            botoes.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            obj.SetActive(false);
            botoes.SetActive(false);
        }
    }
}

