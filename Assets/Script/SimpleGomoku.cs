using UnityEngine;
using System.Collections;

public class SimpleGomoku : MonoBehaviour {

    Gomoku.GomokuGame game;
    int winPiece = 0;
    string[] pieceUI = new string[] { "　", "●", "○" };

    public int winCount = 5;
    public int row = 15;
    public int col = 15;

    private void Start()
    {
        game = new Gomoku.GomokuGame();
        game.Init(winCount, row, col);
    }

    private void OnGUI()
    {
        var checkerBoard = game.chess;
        for (var r = 0; r < checkerBoard.GetLength(0); ++r)
        {
            GUILayout.BeginHorizontal();
            for(var c = 0; c < checkerBoard.GetLength(1);++c)
            {
                var piece = game.GetCurrentPlayerPiece();
                var chess = checkerBoard[r, c];
                if(GUILayout.Button(pieceUI[chess]) && chess == 0 && winPiece == 0)
                {
                    game.Update(r, c);
                    if(game.CheckWin(r,c))
                    {
                        winPiece = piece;
                    }
                }
            }
            GUILayout.EndHorizontal();
        }

        if (winPiece != 0)
            GUILayout.Label("Player " + winPiece + " is winner");
        else if(!game.CanMove())
            GUILayout.Label("tie");
    }
}
