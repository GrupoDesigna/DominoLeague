using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple UI manager that prints the current board state,
/// the player's hand, a basic scoreboard and whose turn it is.
/// This is intended for a very small offline prototype.
/// </summary>
public class DominoUIManager : MonoBehaviour
{
    public GameManager GameManager;

    [Header("UI References")]
    public Text PlayerHandText;
    public Text BoardText;
    public Text ScoreText;
    public Text TurnText;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (GameManager != null)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (GameManager == null)
            return;

        UpdateTurnText();
        UpdateBoardText();
        UpdateHandText();
        UpdateScoreText();
    }

    private void UpdateTurnText()
    {
        int index = GameManager.CurrentPlayerIndex;
        if (index >= 0 && index < GameManager.Players.Count)
        {
            TurnText.text = $"Turno: {GameManager.Players[index].Name}";
        }
    }

    private void UpdateBoardText()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var tile in GameManager.Board.Tiles)
        {
            sb.Append($"[{tile.Left}|{tile.Right}] ");
        }
        BoardText.text = sb.ToString();
    }

    private void UpdateHandText()
    {
        int index = GameManager.CurrentPlayerIndex;
        if (index < 0 || index >= GameManager.Players.Count)
            return;

        StringBuilder sb = new StringBuilder();
        foreach (var tile in GameManager.Players[index].Hand)
        {
            sb.Append($"[{tile.Left}|{tile.Right}] ");
        }
        PlayerHandText.text = sb.ToString();
    }

    private void UpdateScoreText()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var player in GameManager.Players)
        {
            sb.AppendLine($"{player.Name}: {player.Hand.Count} fichas");
        }
        ScoreText.text = sb.ToString();
    }
}
