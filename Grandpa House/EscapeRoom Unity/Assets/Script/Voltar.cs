using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour
{
    int cenas;
    // Start is called before the first frame update
    void Start()
    {
        cenas = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(cenas - 1);
        }
    }
    
    public void NextScene(){
        SceneManager.LoadScene(cenas - 1);
    }
}