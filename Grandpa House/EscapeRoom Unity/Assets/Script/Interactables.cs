using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{
    public Item item;

    public UnityEvent onInteract;

    [HideInInspector]
    public bool isMoving;
    
}
