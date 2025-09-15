using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicialMenu : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject painelSair;
    [SerializeField] private string CutsceneInicial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AbrirSair();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(CutsceneInicial);
    }
    public void AbrirSair()
    {
        painelSair.SetActive(true);
        painelMenuPrincipal.SetActive(false);
    }
    public void SairJogo()
    {
        Application.Quit();
    }
    public void AbrirMenu()
    {
        painelMenuPrincipal.SetActive(true);
        painelSair.SetActive(false);
    }
}
