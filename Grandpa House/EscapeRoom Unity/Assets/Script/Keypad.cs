using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Keypad : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI Ans;
    private string answer = "1412";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Enter()
    {
        if(Ans.text == answer){
            Ans.text = "CERTOU";
        }else{
            Ans.text = "ERROR  ";
        }
        Invoke("Clear", 2.0f);
    }
    private void Clear()
    {
        Ans.text = "";
    }
}
