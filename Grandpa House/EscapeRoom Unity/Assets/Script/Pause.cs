using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void Pausado(){
        Time.timeScale = 0; //pausa
    }

    public void SairPause(){
        Time.timeScale = 1; //rodando
    }
}