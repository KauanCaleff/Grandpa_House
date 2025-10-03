using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Uimanager : MonoBehaviour
{
    public static Uimanager Instance;
    public GameObject handCursor;
    public GameObject Interagirbutton;
    public GameObject invetarioImage;
    public TextMeshProUGUI[] invetarioItens;
    public TextMeshProUGUI infoText;
    public InputActionReference interactionInputAction;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHandCursor(bool state)
    {
        handCursor.SetActive(state);
    }
    public void SetInteragir(bool state)
    {
        Interagirbutton.SetActive(state);
    }
}
