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
    private Inventario inventario;
    public InputActionReference interactionInputAction;

    private void Awake()
    {
        Instance = this;
        inventario = GetComponent<Inventario>();
    }
    

    private void OnEnable()
    {
        interactionInputAction.action.performed += InventarioI;
    }

    private void OnDisable()
    {
        interactionInputAction.action.performed -= InventarioI;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InventarioI(InputAction.CallbackContext inv)
    {
        invetarioImage.SetActive(!invetarioImage.activeInHierarchy);
    }
    public void SetItens(Item item, int index)
    {
        invetarioItens[index].text = item.CollectMessage;
        infoText.text = item.CollectMessage;
        Debug.Log(infoText);
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
