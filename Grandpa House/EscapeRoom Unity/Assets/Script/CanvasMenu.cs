using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenu : MonoBehaviour
{
    public GameObject MenuPCanvas; // arraste aqui o canvas que só deve aparecer 1 vez
    public GameObject MenuOCanvas;

    void Start()
    {
        // Verifica se já visitou a cena antes
        if (PlayerPrefs.GetInt("Scene_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, 0) == 0)
        {
            // Primeira vez = ativa o Canvas
            MenuPCanvas.SetActive(true);
            MenuOCanvas.SetActive(false);

            // Salva que a cena já foi rodada
            PlayerPrefs.SetInt("Scene_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.Save();
        }
        else
        {
            // Não é a primeira vez = desativa o Canvas
            MenuPCanvas.SetActive(false);
            MenuOCanvas.SetActive(true);
        }
    }
}

