using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Item : ScriptableObject
{
    public bool grabbable;

    public string name;
    [Header("Som")]
    public string Audio;
}
