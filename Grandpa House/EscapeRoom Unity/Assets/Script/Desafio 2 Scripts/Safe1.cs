using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class Safe1 : MonoBehaviour
{
    public string input = "";
    public string code = "1212";
    public int maxString = 4;
    public GameObject obj;
    public Text uiText;

    public GameObject[] buttons = new GameObject[10];

    public Transform handle;
    public Transform handleTarget;
    public Transform door;
    public Transform doorTarget;

    private void OnEnable()
    {
        // Garante que o Input System ou o teclado estão funcionando
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            keyboard.onTextInput += OnKeyboardInput;
        }
    }

    private void OnDisable()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            keyboard.onTextInput -= OnKeyboardInput;
        }
    }

    // Função para entradas do novo Input System (teclado ou joystick)
    private void OnKeyboardInput(char c)
    {
        if (char.IsDigit(c))
        {
            int digit = c - '0';
            PressButton(digit.ToString(), digit);
        }
    }

    // Função que também será chamada pelos botões da UI (toque na tela)
    public void OnButtonPress(string digit)
    {
        int d = int.Parse(digit);
        PressButton(digit, d);
    }

    void PressButton(string digit, int index)
    {
        input += digit;
        if (index >= 0 && index < buttons.Length && buttons[index] != null)
        {
            var renderer = buttons[index].GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
                StartCoroutine(ResetButtonColor(renderer));
            }
        }
    }

    IEnumerator ResetButtonColor(Renderer renderer)
    {
        yield return new WaitForSeconds(0.1f);
        renderer.material.color = Color.white;
    }

    void FixedUpdate()
    {
        if (input == code)
        {
            if (obj) obj.SetActive(true);
            uiText.color = Color.green;
            Open();
        }

        if (input.Length > maxString)
        {
            input = "";
        }

        uiText.text = input;
    }

    void Open()
    {
        handle.rotation = Quaternion.Euler(handle.rotation.x, handle.rotation.y, handleTarget.rotation.eulerAngles.z);
        StartCoroutine(DoorOpen());
    }

    IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(1f);
        door.rotation = Quaternion.Euler(door.rotation.eulerAngles.x, doorTarget.rotation.eulerAngles.y, door.rotation.eulerAngles.z);
        uiText.gameObject.SetActive(false);
    }
}