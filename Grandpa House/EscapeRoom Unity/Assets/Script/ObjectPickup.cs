using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public GameObject key;
    public GameObject playerRightHand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpObject()
    {
        key.transform.SetParent(playerRightHand.transform);
        key.transform.localPosition = new Vector3(0f, 0f, 0f);

        key.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PickableObject")){
            key = other.gameObject;
        }
    }
}
