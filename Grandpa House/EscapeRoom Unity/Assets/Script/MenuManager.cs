using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private string nomedoLevelDeJogo;
    [SerializeField] private GameObject painelMenuPrincipal;
    //[SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelSair;

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

    /*public void AbrirOpcoes()
    {
        painelMenuPrincipal.SetActive(false);
        //painelOpcoes.SetActive(true);
    }

    public void Fecharopcoes()
    {
        //painelOpcoes.SetActive(false);
        painelMenuPrincipal.SetActive(true);
    }*/

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