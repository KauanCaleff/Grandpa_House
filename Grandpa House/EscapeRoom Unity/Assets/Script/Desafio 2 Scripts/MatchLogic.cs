using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchLogic : MonoBehaviour
{
    static MatchLogic Instance;

    public int maxPoints=5;
    public Text pointsText;
    public GameObject levelCompletedUI;
    private int points=0;

    public Mouse playerMouse;

    public GameObject minigameUI;    
    public GameObject luzes;
    // Start is called before the first frame update
    void Start()
    {
       Instance = this; 
    }

    void UpdatePotinsText(){
        pointsText.text = points + "/" + maxPoints;
        if (points == maxPoints){
            levelCompletedUI.SetActive(false);
            luzes.SetActive(true);
        }
    }

    public static void AddPoint(){
        AddPoints(1);
    }

    public static void AddPoints(int points){
        Instance.points += points;
        Instance.UpdatePotinsText();
    }

    public void OpenMinigame()
    {
        minigameUI.SetActive(true);

        if (playerMouse != null)
            playerMouse.LockMouse(); // trava a câmera e libera o cursor
    }

    // 🔌 Quando o jogador fecha o painel elétrico
    public void CloseMinigame()
    {
        minigameUI.SetActive(false);

        if (playerMouse != null)
            playerMouse.UnlockMouse(); // destrava a câmera e bloqueia o cursor
    }
}
