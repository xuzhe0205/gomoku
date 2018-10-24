using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cross : MonoBehaviour {

    public int crossR;
    public int crossC;
    public Board board;
    public Texture2D imgBlack;
    public Texture2D imgWhite;
    Sprite s;

    public void CrossClick () {
        var winner = board.chessGame.Winner;
        var img = new Texture2D[] { imgWhite, imgBlack };
        if (winner== 0 && board.chessGame.chess[crossR, crossC] == 0)
        {
            board.chessGame.Update(crossR, crossC);
            s = Sprite.Create(img[board.chessGame.GetCurrentPlayerPiece() - 1],
                new Rect(0, 0, img[board.chessGame.GetCurrentPlayerPiece() - 1].width,
                img[board.chessGame.GetCurrentPlayerPiece() - 1].height), Vector2.zero);
            this.GetComponent<Image>().sprite = s;
            if (board.chessGame.CheckWin(crossR, crossC))
            {
                winner = board.chessGame.chess[crossR, crossC];
            }
        }
        if (!board.chessGame.CanMove())
        {
            print("We have a tie!");
        }
        else if (winner != 0)
        {
            print("Congrats! " + "Player " + winner + " you won!");
        }
    }
}
