using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    Gomoku.GomokuGame chessGame;
    public int winCount = 5;
    public int r = 15;
    public int c = 15;
	public void Start()
    {
        chessGame = new Gomoku.GomokuGame();
        chessGame.Init(winCount, r, c);
    }
}
