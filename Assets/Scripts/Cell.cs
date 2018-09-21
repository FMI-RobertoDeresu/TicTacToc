using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text Label;
    public Button Button;

    public Main Main { get; set; }

    public void Fill()
    {
        Button.interactable = false;
        Label.text = Main.GetTurnCharacter();
        Main.SwitchTurn();
    }

    public void Reset()
    {
        Button.interactable = true;
        Label.text = string.Empty;
    }
}