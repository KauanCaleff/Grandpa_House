using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
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
    [SerializeField] private GameObject pause;
    [SerializeField] private PlayableDirector timeline;

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
    /*public void MenuOp()
    {
        SceneManager.LoadScene(MenuOpcoes);
    }*/
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
        Time.timeScale = 0;
        painelMenuOpcoes.SetActive(true);
        painelTutorial.SetActive(false);
        painelSair.SetActive(false);
        pause.SetActive(false);
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

    public void SairPause()
    {
        Time.timeScale = 1; //rodando
        painelMenuOpcoes.SetActive(false);
        pause.SetActive(true);

    }
    public void Final()
    {
        // Aqui voc� marca que j� passou pelo jogo
        PlayerPrefs.SetInt("VoltouDoJogo", 1);

        // Agora carrega a cena que tem a cutscene final
        SceneManager.LoadScene(CutsceneInicial);
    }
}