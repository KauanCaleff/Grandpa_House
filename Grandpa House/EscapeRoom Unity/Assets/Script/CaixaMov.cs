using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using FMODUnity;

public class CaixaMov : MonoBehaviour, IInteractable
{
    [SerializeField] private ScriptableObject scriptableObject;

    public Transform targetPosition;    // Posição de destino
    public float moveSpeed = 2f;        // Velocidade de movimento

    private Vector3 startPosition;      // Posição inicial
    private bool isMoving = false;
    private bool isAtTarget = false;    // Verifica se está no destino

    //private StudioEventEmitter emitter;

    private void Start()
    {
        startPosition = transform.position;
        //emitter = GetComponent<StudioEventEmitter>();
    }
    
    public void IInteract()
    {
        if (scriptableObject.name == "Caixa")
        {
            if (!isAtTarget)
            {
                StartCoroutine(MoveToPosition(targetPosition.position));
            }
            else
            {
                StartCoroutine(MoveToPosition(startPosition));
            }

            isAtTarget = !isAtTarget;
            //emitter.Play();
        }
    }



    IEnumerator MoveToPosition(Vector3 destination)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }

}
