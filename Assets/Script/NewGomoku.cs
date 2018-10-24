using UnityEngine;
using System.Collections;

public class NewGomoku : MonoBehaviour {
    Gomoku.GomokuGame chessGame;
    public int winCount = 5;
    public int row = 15;
    public int col = 15;
    public int winner;
    // Use this for initialization
    
    public void Start () {
        winner = 0;
        chessGame = new Gomoku.GomokuGame();
        chessGame.Init(winCount,row,col);
	}
    public void OnGUI()
    {
        var chessBoard = chessGame.chess;
        var chessPiece = new string[] { "　", "●", "□" };
        GUILayout.Button("Welome to Oliver's Gomoku Battles!");
        for (var i = 0; i < chessBoard.GetLength(0); i++)
        {
            GUILayout.BeginHorizontal();
            for (var j = 0; j < chessBoard.GetLength(1); j++)
            {
                
                if (GUILayout.Button(chessPiece[chessBoard[i, j]],GUILayout.Width(25)) && winner == 0 && chessBoard[i, j] == 0)
                {
                    chessGame.Update(i, j);
                    if (chessGame.CheckWin(i, j))
                    {
                        winner = chessBoard[i, j];
                    }
                }
            }
            GUILayout.EndHorizontal();
        }
        if (!chessGame.CanMove())
        {
            GUILayout.Box("We have a tie!");
        }
        else if (winner != 0)
        {
            GUILayout.Box("Congrats! " + "Player " + winner + " you won!");
        }
        if (GUI.Button(new Rect((Screen.width - 150) / 2.0f, (Screen.height - 50) / 2.0f, 150, 50), "Rematch"))
        {
            Start();
            OnGUI();
        }
        else if (GUI.Button(new Rect((Screen.width - 150) / 2.0f, (Screen.height - 200) / 2.0f, 150, 50), "Quit"))
        {
            Application.Quit();
        }
    }
}
