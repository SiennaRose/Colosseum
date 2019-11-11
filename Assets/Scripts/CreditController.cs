using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject QuitButton;
    public GameObject score; 

    public void Awake()
    {
        PlayButton = GameObject.Find("PlayAgain");
        QuitButton = GameObject.Find("QuitButton2");
        
    }

    void Start()
    {
        score = GameObject.Find("ScoreText");
        score.GetComponent<Text>().text = "You Have Died: Score " + UIController.Instance.myPlayer.pts.ToString();
    }

    public void playButtonClicked()
    {
        UIController.Instance.PlayGame();
    }

    public void quitButtonClicked()
    {
        UIController.Instance.QuitGame();
    }
}
