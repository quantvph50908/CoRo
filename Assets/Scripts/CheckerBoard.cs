using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckerBoard : MonoBehaviour
{
    public Sprite XSprite;
    public Sprite OSprite;
    private Image Image;
    private Button Button;
    private Board board;
    private bool isMarked = false;

    public int row;
    public int column;

    private MusicManager musicManager;
    public TextMeshProUGUI WinText;
    public GameObject ImageGameOver;
    public Sprite defaultSprite;

    void Start()
    {
        Image = GetComponent<Image>();
        Button = GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
        board = FindObjectOfType<Board>();
        musicManager = FindObjectOfType<MusicManager>();

        if (board == null || musicManager == null)
        {
            return;
        }
    }

    private void ChangeImage(string s)
    {
        Image.sprite = (s == "x") ? XSprite : OSprite;
    }

    public void OnClick()
    {
        if (isMarked) return;

        ChangeImage(board.CurrentTurn);
        isMarked = true;
        musicManager.PlayPlaceSound();

        if (board.Check(row, column))
        {
            string winnerText = board.Winner.ToUpper() + " Wins!";
            Menu menu = FindObjectOfType<Menu>();
            if (menu != null)
            {
                menu.ShowGameOverScreen(winnerText);
            }
            musicManager.PlayWinSound();
        }
        else if (IsDraw())
        {
            Menu menu = FindObjectOfType<Menu>();
            if (menu != null)
            {
                menu.ShowGameOverScreen("Game Draw!");
            }
            musicManager.PlayDrawSound();
        }
        board.CurrentTurn = (board.CurrentTurn == "x") ? "o" : "x";
    }

    private bool IsDraw()
    {
        CheckerBoard[] allCells = FindObjectsOfType<CheckerBoard>();
        foreach (var cell in allCells)
        {
            if (!cell.isMarked)
            {
                return false;
            }
        }
        return true;
    }

    public void ResetCell()
    {
        Image.sprite = defaultSprite;
        isMarked = false;
    }
}