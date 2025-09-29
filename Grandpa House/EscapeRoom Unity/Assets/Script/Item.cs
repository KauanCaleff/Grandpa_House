using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Item : ScriptableObject
{
    public bool grabbable;
    //audio
    public string name;
    [Header("Invetario")]
    public bool InventarioItem;
    public string CollectMessage;
}
