using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public string sceneGame;
    public PlayableDirector cutsceneFinal;
    public PlayableDirector cutsceneInicial;


    void Start()
    {
        Debug.Log("Cena carregada");

        if (PlayerPrefs.GetInt("VoltouDoJogo", 0) == 1)
        {
            Debug.Log("Cutscene final");
            cutsceneFinal.Play();
            cutsceneInicial.Stop(); // Precisa existir e estar desativada no "Play On Awake"
            PlayerPrefs.SetInt("VoltouDoJogo", 0);
        }
        else
        {
            Debug.Log("Cutscene inicial ativada!");
            cutsceneInicial.Play(); // Só toca se for a primeira vez na cena
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneGame);
    }

}
