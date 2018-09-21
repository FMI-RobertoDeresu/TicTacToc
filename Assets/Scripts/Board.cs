using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    private readonly Cell[] _cells = new Cell[9];

    private readonly int[][] _winningConfigurations =
    {
        new[] { 0, 1, 2 },
        new[] { 3, 4, 5 },
        new[] { 6, 7, 8 },
        new[] { 0, 3, 6 },
        new[] { 1, 4, 7 },
        new[] { 2, 5, 8 },
        new[] { 0, 4, 8 },
        new[] { 2, 4, 6 }
    };

    public GameObject CellPrefab;
    public GameObject Lines;

    public void Build(Main main)
    {
        for (var i = 0; i < 9; i++)
        {
            var newCell = Instantiate(CellPrefab, transform).GetComponent<Cell>();
            newCell.Main = main;
            _cells[i] = newCell;
        }
    }

    public void Reset()
    {
        foreach (var cell in _cells)
            cell.Reset();
    }

    public bool CheckForWinner()
    {
        var isWinner = _winningConfigurations.Any(x => CheckConfiguration(x[0], x[1], x[2]));
        return isWinner;
    }

    private bool CheckConfiguration(int first, int second, int third)
    {
        var firstValue = _cells[first].Label.text;
        var secondValue = _cells[second].Label.text;
        var thirdValue = _cells[third].Label.text;

        if (string.IsNullOrEmpty(firstValue))
            return false;

        var hasSameValue = firstValue == secondValue && secondValue == thirdValue;
        return hasSameValue;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        Lines.SetActive(active);
    }
}