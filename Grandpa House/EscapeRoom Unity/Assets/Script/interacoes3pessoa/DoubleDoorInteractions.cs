using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorInteractions : MonoBehaviour, IInteractable
{
    [Header("Referência ao player")]
    [SerializeField] private ObjectPickup playerPickup;   // arrasta o Player aqui

    [Header("Folhas da porta")]
    [SerializeField] private Transform leftDoor;          // folha esquerda
    [SerializeField] private Transform rightDoor;         // folha direita

    [Header("Config da animação")]
    public float openAngle = 90f;            // quanto cada folha gira
    public float animationDuration = 0.75f;

    private bool isOpen = false;
    private bool isAnimating = false;

    private Quaternion leftClosedRot;
    private Quaternion leftOpenRot;
    private Quaternion rightClosedRot;
    private Quaternion rightOpenRot;

    private void Awake()
    {
        if (leftDoor == null || rightDoor == null)
        {
            Debug.LogError("[DoubleDoorInteraction] As referências leftDoor/rightDoor não estão atribuídas!");
            enabled = false;
            return;
        }

        // Guardar rotações fechadas
        leftClosedRot = leftDoor.localRotation;
        rightClosedRot = rightDoor.localRotation;

        // definir rotações abertas (uma pra cada lado)
        leftOpenRot = leftClosedRot * Quaternion.Euler(0f, -openAngle, 0f);  // abre pra esquerda
        rightOpenRot = rightClosedRot * Quaternion.Euler(0f, openAngle, 0f); // abre pra direita
    }

    public void IInteract()
    {
        if (isAnimating)
            return;

        if (!isOpen)
        {
            // porta fechada → tentar abrir
            if (playerPickup != null && playerPickup.HasKey)
            {
                StartCoroutine(AnimateDoors(true));
            }
            else
            {
                Debug.Log("[DoubleDoorInteraction] Porta trancada. Precisa da chave.");
            }
        }
        else
        {
            // porta aberta → fechar
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
            // suavização tipo smoothstep
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