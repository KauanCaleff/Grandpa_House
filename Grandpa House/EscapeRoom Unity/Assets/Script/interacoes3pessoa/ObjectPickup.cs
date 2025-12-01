using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform rightHand;  

    public bool HasKey { get; private set; }

    public void SetHasKey(bool value)
    {
        HasKey = value;
        Debug.Log("[ObjectPickup] HasKey = " + HasKey);
    }


    public void AttachToRightHand(Transform target, Vector3 localPos, Vector3 localEuler)
    {
        if (rightHand == null)
        {
            Debug.LogWarning("[ObjectPickup] rightHand não está atribuída no Inspector.");
            return;
        }

        target.SetParent(rightHand);
        target.localPosition = localPos;
        target.localRotation = Quaternion.Euler(localEuler);
    }
}