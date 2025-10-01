using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trig : MonoBehaviour
{
    public GameObject obj;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            obj.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            obj.SetActive(false);
        }
    }
}

