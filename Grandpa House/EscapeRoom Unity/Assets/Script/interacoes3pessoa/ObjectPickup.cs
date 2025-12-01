using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform rightHand;  

    public bool HasKey;

    public void SetHasKey(bool value)
    {
        HasKey = value;
    }

    public void AttachToRightHand(Transform target, Vector3 localPos, Vector3 localEuler)
    {
        target.SetParent(rightHand);
        target.localPosition = localPos;
        target.localRotation = Quaternion.Euler(localEuler);
    }
}