using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorInteractions : MonoBehaviour, IInteractable
{
    [SerializeField] private ObjectPickup playerPickup;   

    [SerializeField] private Transform leftDoor;          
    [SerializeField] private Transform rightDoor;        

    public float openAngle = 90f;            
    public float animationDuration = 0.75f;

    private bool isOpen = false;
    private bool isAnimating = false;

    private Quaternion leftClosedRot;
    private Quaternion leftOpenRot;
    private Quaternion rightClosedRot;
    private Quaternion rightOpenRot;

    private void Awake()
    {
        leftClosedRot = leftDoor.localRotation;
        rightClosedRot = rightDoor.localRotation;

        leftOpenRot = leftClosedRot * Quaternion.Euler(0f, -openAngle, 0f); 
        rightOpenRot = rightClosedRot * Quaternion.Euler(0f, openAngle, 0f); 
    }

    public void IInteract()
    {
        if (!isOpen)
        {
            var controller = playerPickup.GetComponent<PlayerController1>();
            controller.PlayOpenDoorAnimation();
            
            if (playerPickup.HasKey)
            {
                StartCoroutine(AnimateDoors(true));
            }
            else
            {
                Debug.Log("Porta trancada. Precisa da chave.");
            }
        }
        else
        {
            StartCoroutine(AnimateDoors(false));
        }
    }

    private IEnumerator AnimateDoors(bool open)
    {
        isAnimating = true;

        Quaternion leftStart = leftDoor.localRotation;
        Quaternion rightStart = rightDoor.localRotation;

        Quaternion leftTarget = open ? leftOpenRot : leftClosedRot;
        Quaternion rightTarget = open ? rightOpenRot : rightClosedRot;

        float t = 0f;

        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / animationDuration);

            float eased = normalized * normalized * (3f - 2f * normalized);

            leftDoor.localRotation = Quaternion.Slerp(leftStart, leftTarget, eased);
            rightDoor.localRotation = Quaternion.Slerp(rightStart, rightTarget, eased);

            yield return null;
        }

        leftDoor.localRotation = leftTarget;
        rightDoor.localRotation = rightTarget;

        isOpen = open;
        isAnimating = false;
    }
}