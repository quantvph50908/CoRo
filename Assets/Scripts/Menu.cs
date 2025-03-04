using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ImageMenu, ImageGamePlay, ImageGameOver,ImageSetting,ImageHowToPlay;
    public TextMeshProUGUI WinText;

    void Start()
    {
        ImageMenu.SetActive(true);
        ImageGamePlay.SetActive(false);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(false);

    }

    public void Play()
    {
        ImageMenu.SetActive(false);
        ImageGamePlay.SetActive(true);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(false);

        // Reset tất cả các ô cờ
        CheckerBoard[] allCells = FindObjectsOfType<CheckerBoard>();
        foreach (var cell in allCells)
        {
            cell.ResetCell();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        ImageMenu.SetActive(false);
        ImageGamePlay.SetActive(false);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(true);
        ImageHowToPlay.SetActive(false);
    }

    public void PlayAgain()
    {
        ImageMenu.SetActive(false);
        ImageGamePlay.SetActive(true);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(false);

        // Reset bàn cờ
        Board board = FindObjectOfType<Board>();
        if (board != null)
        {
            board.ResetBoard();
        }

        // Reset các ô cờ
        CheckerBoard[] allCells = FindObjectsOfType<CheckerBoard>();
        foreach (var cell in allCells)
        {
            cell.ResetCell();
        }
    }


    public void MainMenu()
    {
        ImageMenu.SetActive(true);
        ImageGamePlay.SetActive(false);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(false);
    }    


    public void RePlay()
    {
        ImageMenu.SetActive(false);
        ImageGamePlay.SetActive(true);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(false);

        // Reset bàn cờ
        Board board = FindObjectOfType<Board>();
        if (board != null)
        {
            board.ResetBoard();
        }

        // Reset các ô cờ
        CheckerBoard[] allCells = FindObjectsOfType<CheckerBoard>();
        foreach (var cell in allCells)
        {
            cell.ResetCell();
        }
    }    
    public void BackGame()
    {
        ImageMenu.SetActive(true);
        ImageGamePlay.SetActive(false);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(false);
    }

    public void HowToPlay()
    {
        ImageMenu.SetActive(false);
        ImageGamePlay.SetActive(false);
        ImageGameOver.SetActive(false);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(true);
    }    

    public void ShowGameOverScreen(string winner)
    {
        ImageMenu.SetActive(false);
        ImageGamePlay.SetActive(false);
        ImageGameOver.SetActive(true);
        ImageSetting.SetActive(false);
        ImageHowToPlay.SetActive(false);

        WinText.text = winner;
    }    

}
