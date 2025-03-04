using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject board;
    public GridLayoutGroup GridLayoutGroup;
    public int boardSize = 13;
    public GameObject CheckerBoard;
    public string CurrentTurn = "x";

    private string[,] Matrix;
    public string Winner = "";

    void Start()
    {
        Matrix = new string[boardSize, boardSize];
        GridLayoutGroup.constraintCount = boardSize;
        CreateBoard();
    }

    private void CreateBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                GameObject CheckerBoardTramsFrom = Instantiate(CheckerBoard, board.transform);
                CheckerBoard checkerBoard = CheckerBoardTramsFrom.GetComponent<CheckerBoard>();
                checkerBoard.row = i;
                checkerBoard.column = j;
                Matrix[i, j] = "";
            }
        }
    }

    public bool Check(int row, int column)
    {
        if (row < 0 || row >= boardSize || column < 0 || column >= boardSize || Matrix[row, column] != "")
        {
            return false;
        }

        Matrix[row, column] = CurrentTurn;

        // Kiểm tra 4 hướng
        if (CheckDirection(row, column, 0, 1) ||  // Ngang
            CheckDirection(row, column, 1, 0) ||  // Dọc
            CheckDirection(row, column, 1, 1) ||  // Chéo chính
            CheckDirection(row, column, 1, -1))   // Chéo phụ
        {
            Winner = CurrentTurn;
            Debug.Log($"Player {Winner} wins!");
            return true;
        }

        return false;
    }

    private bool CheckDirection(int row, int col, int dx, int dy)
    {
        int count = 1;
        count += CountConsecutive(row, col, dx, dy);
        count += CountConsecutive(row, col, -dx, -dy);
        return count >= 5;
    }

    private int CountConsecutive(int row, int col, int dx, int dy)
    {
        int count = 0;
        int r = row + dx, c = col + dy;

        while (r >= 0 && r < boardSize && c >= 0 && c < boardSize && Matrix[r, c] == CurrentTurn)
        {
            count++;
            r += dx;
            c += dy;
        }

        return count;
    }


    public void ResetBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Matrix[i, j] = ""; // Reset ô cờ
            }
        }

        Winner = ""; // Reset trạng thái thắng
        CurrentTurn = "x"; // Reset lượt chơi về "x"
        Debug.Log("Game Reset!");
    }

}
