using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    [Header("Referência ao player")]
    [SerializeField] private ObjectPickup playerPickup; // arrasta o Player aqui

    [Header("Porta / Pivot")]
    [SerializeField] private Transform doorTransform;

    [Header("Config da animação")]
    public float openAngle = 90f;
    public float animationDuration = 0.75f;
    public bool openClockwise = true;

    private bool isOpen = false;
    private bool isAnimating = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Awake()
    {
        if (doorTransform == null)
            doorTransform = transform;

        closedRotation = doorTransform.localRotation;

        float angle = openClockwise ? openAngle : -openAngle;
        openRotation = closedRotation * Quaternion.Euler(0f, angle, 0f);
    }

    public void IInteract()
    {
        if (isAnimating)
            return;

        if (!isOpen)
        {
            // ⬇️ AQUI é onde a chave entra:
            if (playerPickup != null && playerPickup.HasKey)
            {
                StartCoroutine(AnimateDoor(true));
            }
            else
            {
                Debug.Log("Porta trancada. Você precisa da chave.");
            }
        }
        else
        {
            StartCoroutine(AnimateDoor(false));
        }
    }

    private IEnumerator AnimateDoor(bool open)
    {
        isAnimating = true;

        Quaternion startRot = doorTransform.localRotation;
        Quaternion targetRot = open ? openRotation : closedRotation;

        float t = 0f;

        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / animationDuration);
            float eased = normalized * normalized * (3f - 2f * normalized);

            doorTransform.localRotation = Quaternion.Slerp(startRot, targetRot, eased);

            yield return null;
        }

        doorTransform.localRotation = targetRot;
        isOpen = open;
        isAnimating = false;
    }
}
