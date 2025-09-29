using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
     public List<Item> itens;

     public void AddItem(Item item)
     {
        if (itens.Contains(item))
        {
            return;
        }
        Uimanager.Instance.SetItens(item, itens.Count);
        itens.Add(item);
     }

}
