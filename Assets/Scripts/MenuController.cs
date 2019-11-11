using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject PlayButton;
    public GameObject QuitButton;

    public void Awake()
    {
        Panel_Menu = GameObject.Find("Panel_Menu");
        Panel_Menu.SetActive(true);

        PlayButton = GameObject.Find("PlayButton");
        QuitButton = GameObject.Find("QuitButton");
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
