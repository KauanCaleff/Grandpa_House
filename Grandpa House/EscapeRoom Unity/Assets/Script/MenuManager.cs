using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string CutsceneInicial;
    [SerializeField] private string nomedoLevelDeJogo;
    [SerializeField] private string MenuOpcoes;
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject painelMenuOpcoes;
    [SerializeField] private GameObject painelSair;
    [SerializeField] private GameObject painelTutorial;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AbrirSair();
        }
    }
    public void Jogar()
    {
        SceneManager.LoadScene(nomedoLevelDeJogo);
    }
    public void MenuOp()
    {
        SceneManager.LoadScene(MenuOpcoes);
    }
    public void Play()
    {
        SceneManager.LoadScene(CutsceneInicial);
    }

    public void AbrirOpcoes()
    {
        painelMenuPrincipal.SetActive(false);
        painelMenuOpcoes.SetActive(true);
    }

    public void Fecharopcoes()
    {
        painelMenuOpcoes.SetActive(false);
        painelMenuPrincipal.SetActive(true);
    }

    public void AbrirSair()
    {
        painelSair.SetActive(true);
        //painelMenuPrincipal.SetActive(false);
        painelMenuOpcoes.SetActive(false);
    }
    public void SairJogo()
    {
        Application.Quit();
    }

    public void AbrirMenuPrincipal()
    {
        painelMenuPrincipal.SetActive(true);
        painelSair.SetActive(false);
    }
    public void AbrirMenuOp()
    {
        painelMenuOpcoes.SetActive(true);
        painelSair.SetActive(false);
    }
    public void AbrirTutorial()
    {
        painelMenuOpcoes.SetActive(false);
        painelTutorial.SetActive(true);
    }
    public void SairTutorial()
    {
        painelTutorial.SetActive(false);
        painelMenuOpcoes.SetActive(true);
    }
}