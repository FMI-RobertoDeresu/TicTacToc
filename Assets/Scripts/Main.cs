using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Board Board;
    public GameObject Winner;
    public GameObject Menu;

    private bool _xTurn = true;
    private int _turnCount;

    private void Awake()
    {
        Board.Build(this);
        Menu.SetActive(true);
    }

    public void Play()
    {
        ResetGame();
        Menu.SetActive(false);
        Board.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SwitchTurn()
    {
        _turnCount++;

        var hasWinner = Board.CheckForWinner();
        if (hasWinner || _turnCount == 9)
        {
            StartCoroutine(EndGame(hasWinner));
            return;
        }

        _xTurn = !_xTurn;
    }

    public string GetTurnCharacter()
    {
        return _xTurn ? "X" : "O";
    }

    private IEnumerator EndGame(bool hasWinner)
    {
        var winnerLabel = Winner.GetComponentInChildren<Text>();
        winnerLabel.text = hasWinner ? GetTurnCharacter() + " " + "won!" : "Draw";
        Board.SetActive(false);
        Winner.SetActive(true);

        var wait = new WaitForSeconds(3);
        yield return wait;

        Winner.SetActive(false);
        Menu.SetActive(true);
    }

    private void ResetGame()
    {
        Board.Reset();
        _turnCount = 0;
        _xTurn = true;
    }
}