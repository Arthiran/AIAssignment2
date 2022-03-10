using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeManager : MonoBehaviour
{
    public List<BoxColliderManager> BoxManagers = new List<BoxColliderManager>();

    private List<int> Board = new List<int>();

    private int TemporarySwitch = 0;

    private bool isFinished = false;

    private void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            Board.Add(-1);
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            for (int i = 0; i < Board.Count; i++)
            {
                Debug.Log(Board[i]);
            }
        }
    }

    public void UpdateBoard(int _BoxNumber, int _Value, bool _FromPlayer)
    {
        Board[_BoxNumber] = _Value;
        int VictoryCheck = CheckForVictory(Board);
        if (VictoryCheck == 0)
        {
            Debug.Log("PLAYER VICTORY");
            isFinished = true;
        }
        else if (VictoryCheck == 1)
        {
            Debug.Log("AI VICTORY");
            isFinished = true;
        }

        if (_FromPlayer && !isFinished)
        {
            AIMove();
        }
    }

    private void AIMove()
    {
        int bestScore = -100;
        int bestMove = -100;

        for (int i = 0; i < Board.Count; i++)
        {
            if (Board[i] == -1)
            {
                Board[i] = 1;
                int score = Minimax(Board, 0, false);
                Board[i] = -1;
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }

        for (int i = 0; i < BoxManagers.Count; i++)
        {
            if (i == bestMove)
            {
                BoxManagers[i].PlaceCirclePiece();
            }
        }
    }

    private int Minimax(List<int> _BoardCopy, int _Depth, bool _isMax)
    {
        int VictoryCheck = CheckForVictory(Board);

        if (VictoryCheck != -1)
        {
            if (VictoryCheck == 0)
            {
                return 1;
            }
            else if (VictoryCheck == 1)
            {
                return -1;
            }
        }

        int DrawCheck = CheckForDraw(Board);

        if (DrawCheck == 0)
        {
            return 0;
        }

        if (_isMax)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < _BoardCopy.Count; i++)
            {
                if (_BoardCopy[i] == -1)
                {
                    _BoardCopy[i] = 1;
                    int score = Minimax(_BoardCopy, _Depth + 1, false) + _Depth + 1;
                    _BoardCopy[i] = -1;
                    bestScore = Mathf.Max(score, bestScore);
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < _BoardCopy.Count; i++)
            {
                if (_BoardCopy[i] == -1)
                {
                    _BoardCopy[i] = 0;
                    int score = Minimax(_BoardCopy, _Depth + 1, true) + _Depth + 1;
                    _BoardCopy[i] = -1;
                    bestScore = Mathf.Min(score, bestScore);
                }
            }
            return bestScore;
        }
    }

    private int CheckForVictory(List<int> _CurrentBoard)
    {
        for (int i = 0; i < 2; i++)
        {
            if (_CurrentBoard[0] == i && _CurrentBoard[1] == i && _CurrentBoard[2] == i)
            {
                return i;
            }
            else if (_CurrentBoard[3] == i && _CurrentBoard[4] == i && _CurrentBoard[5] == i)
            {
                return i;
            }
            else if (_CurrentBoard[6] == i && _CurrentBoard[7] == i && _CurrentBoard[8] == i)
            {
                return i;
            }
            else if (_CurrentBoard[0] == i && _CurrentBoard[3] == i && _CurrentBoard[6] == i)
            {
                return i;
            }
            else if (_CurrentBoard[1] == i && _CurrentBoard[4] == i && _CurrentBoard[7] == i)
            {
                return i;
            }
            else if (_CurrentBoard[2] == i && _CurrentBoard[5] == i && _CurrentBoard[8] == i)
            {
                return i;
            }
            else if (_CurrentBoard[0] == i && _CurrentBoard[4] == i && _CurrentBoard[8] == i)
            {
                return i;
            }
            else if (_CurrentBoard[2] == i && _CurrentBoard[4] == i && _CurrentBoard[6] == i)
            {
                return i;
            }
        }

        return -1;
    }

    private int CheckForDraw(List<int> _CurrentBoard)
    {
        int CheckDraw = 0;
        for (int i = 0; i < _CurrentBoard.Count; i++)
        {
            if (_CurrentBoard[i] == -1)
            {
                CheckDraw = 1;
            }
        }

        if (CheckDraw == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public int CheckTurn()
    {
        if (TemporarySwitch == 0)
        {
            TemporarySwitch = 1;
            return 0;
        }
        else
        {
            TemporarySwitch = 0;
            return 1;
        }
    }

    public bool IsFinished()
    {
        return isFinished;
    }
}
