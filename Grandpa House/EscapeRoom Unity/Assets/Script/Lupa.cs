using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : MonoBehaviour, IInteractable
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteragirLupa()
    {
        //spriter.sprite = PapelCZoom;
        //GetComponent<BoxCollider>().enabled = false;
        Debug.Log("funcionou");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            player = collider.GetComponent<PlayerController>();
            player.SetIInteractable(this);
        }
    }

    private void OnTriggerexit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            player.ClearIInstance();
        }
    }

    public void IInteract()
    {
        InteragirLupa();
    }
}
