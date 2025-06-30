using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DominoBoard Board;
    public List<Player> Players = new List<Player>();
    public GameStateMachine StateMachine = new GameStateMachine();
    public List<DominoTile> Deck = new List<DominoTile>();

    private void Start()
    {
        Players.Add(new Player("Player 1"));
        Players.Add(new Player("Player 2"));

        CreateDeck();
        ShuffleDeck();
        DealTiles();

        StateMachine.OnStateChanged += HandleStateChange;
        StateMachine.ChangeState(GameFlowState.Reparto);
    }

    private void HandleStateChange(GameFlowState newState)
    {
        Debug.Log($"Game state changed to: {newState}");
    }

    public void AdvanceGame()
    {
        switch (StateMachine.CurrentState)
        {
            case GameFlowState.Reparto:
                StateMachine.ChangeState(GameFlowState.TurnoJugador);
                break;
            case GameFlowState.TurnoJugador:
                StateMachine.ChangeState(GameFlowState.FinRonda);
                break;
            case GameFlowState.FinRonda:
                StateMachine.ChangeState(GameFlowState.FinPartida);
                break;
        }
    }

    private void CreateDeck()
    {
        Deck.Clear();
        for (int i = 0; i <= 6; i++)
        {
            for (int j = i; j <= 6; j++)
            {
                Deck.Add(new DominoTile(i, j));
            }
        }
    }

    private void ShuffleDeck()
    {
        System.Random rng = new System.Random();
        int n = Deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            DominoTile value = Deck[k];
            Deck[k] = Deck[n];
            Deck[n] = value;
        }
    }

    private void DealTiles()
    {
        int tilesPerPlayer = 7;
        foreach (Player p in Players)
        {
            for (int i = 0; i < tilesPerPlayer; i++)
            {
                if (Deck.Count == 0)
                    break;
                DominoTile tile = Deck[0];
                Deck.RemoveAt(0);
                p.AddTile(tile);
            }
        }
    }
}
