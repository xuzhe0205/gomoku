using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
    public GameObject crossPrefab;
    public Cross[,] boardArr;
    public int r = 15;
    public int c = 15;
    public int winCount = 5;
    Dictionary<int, Cross> crossMap = new Dictionary<int, Cross>();
    public Gomoku.GomokuGame chessGame;
    public float gridFactor = 35 / 535f;
    public float boardFactor = 245 / 535f;
    

    public int MakeKey(float row, float col)
    {
        return (int)(row * 100 + col);
    }

    public void Start()
    {
        chessGame = new Gomoku.GomokuGame();
        chessGame.Init(winCount, r, c);
        SetBoard();
    }

    public float GetCoordinate(float t)
    {
        return 0;
    }

    public void SetBoard()
    {
        boardArr = new Cross[r, c];
        //var obj = GameObject.FindWithTag("GameBoard");
        var tl = GameObject.FindWithTag("topleft");
        var br = GameObject.FindWithTag("bottomright");
        //RectTransform rtBoard = (RectTransform)obj.transform;
        //RectTransform rtButton = (RectTransform)crossPrefab.transform;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                //Find positons
                float xTL = tl.transform.localPosition.x;
                float yTL = tl.transform.localPosition.y;
                float xBR = br.transform.localPosition.x;
                float yBR = br.transform.localPosition.y;
                float row = -yTL + j * (yTL - yBR)/14;
                float col = xTL + i * (xBR - xTL) / 14;
                print(xTL);
                // rtButton.sizeDelta = new Vector2(rtBoard.rect.width * buttonFactor, rtBoard.rect.width * buttonFactor);
                //Clone crossPrefab
                var crossObj = (GameObject)Instantiate(crossPrefab, new Vector3(col, row, 0), Quaternion.identity);
                crossObj.transform.SetParent(gameObject.transform);     //Set them under the 'Board' object
                var crossChess = crossObj.GetComponent<Cross>();
                var pos = crossObj.transform.localPosition;
                pos.x = row;
                pos.y = col;
                crossObj.transform.localPosition = pos;
                //store cross buttons info
                boardArr[i, j] = crossChess;
                crossChess.crossR = i;
                crossChess.crossC = j;
                crossChess.board = this;
                crossChess.name = (crossChess.crossR + " " + crossChess.crossC);
                crossMap.Add(MakeKey(i, j), crossChess);
            }
        }
    }

    public Cross GetCross(float crossR, float crossC)
    {
        Cross crossChess;
        if (crossMap.TryGetValue(MakeKey(crossR, crossC), out crossChess))
        {
            return crossChess;
        }
        return null;
    }

    
}
