using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Title : MonoBehaviour {

    public GameObject chessboard;
    public Button startButton;
    public Button exitButton;
    public string gameScene = "Game";

    public void StartGame()
    {
        Application.LoadLevel(gameScene);
        chessboard.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
