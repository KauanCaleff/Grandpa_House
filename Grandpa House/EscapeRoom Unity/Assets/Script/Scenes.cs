using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public string sceneGame;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneGame);
    }

}
