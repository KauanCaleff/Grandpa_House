using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Item : ScriptableObject
{
    public bool grabbable;
    //audio
    public string name;
    [Header("Inventario")]
    public bool InventarioItem;
    public string CollectMessage;
}
