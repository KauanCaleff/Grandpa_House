using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using UnityEngine.Playables;


public class Keypad : MonoBehaviour, IInteractable
{
    [SerializeField] private string CutsceneInicial;
    [SerializeField]private ScriptableObject scriptableObject;
    [SerializeField]private GameObject ImageKeypad;
    [SerializeField]private TextMeshProUGUI Ans;
    private string answer = "1412";
    public StudioEventEmitter emitter;
    public void IInteract()
    {
        ImageKeypad.SetActive(true);
    }
    public void Number(int number)
    {
        Ans.text += number.ToString();
        emitter.Play();
    }

    public void Enter()
    {
        if(Ans.text == answer){
            Ans.text = "CERTOU";
            Final();
        }else{
            Ans.text = "ERROR  ";
        }
        Invoke("Clear", 2.0f);
    }
    private void Clear()
    {
        Ans.text = "";
    }
    public void Final()
    {
        // Aqui você marca que já passou pelo jogo
        PlayerPrefs.SetInt("VoltouDoJogo", 1);

        // Agora carrega a cena que tem a cutscene final
        SceneManager.LoadScene(CutsceneInicial);
    }
}
