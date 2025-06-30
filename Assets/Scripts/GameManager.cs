using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DominoBoard Board = new DominoBoard();
    public List<Player> Players = new List<Player>();
    public GameStateMachine StateMachine = new GameStateMachine();
    public List<DominoTile> Deck = new List<DominoTile>();

    private int currentPlayerIndex = 0;
    /// <summary>
    /// Exposes the index of the player whose turn is currently active so
    /// that UI elements can display turn information.
    /// </summary>
    public int CurrentPlayerIndex => currentPlayerIndex;
    private int passCount = 0;
    private bool gameEnded = false;

    private void Start()
    {
        Players.Add(new Player("Player 1"));
        Players.Add(new Player("Player 2"));

        StartRound();

        StateMachine.OnStateChanged += HandleStateChange;
    }

    private void HandleStateChange(GameFlowState newState)
    {
        Debug.Log($"Game state changed to: {newState}");
    }

    private void Update()
    {
        if (gameEnded)
            return;

        if (StateMachine.CurrentState == GameFlowState.TurnoJugador)
            PlayTurn();
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

    private void StartRound()
    {
        CreateDeck();
        ShuffleDeck();
        DealTiles();

        currentPlayerIndex = DetermineStartingPlayer();
        DominoTile startTile = ChooseStartingTile(Players[currentPlayerIndex]);
        Players[currentPlayerIndex].PlayTile(startTile, Board, true);
        Debug.Log($"{Players[currentPlayerIndex].Name} inicia con {startTile.Left}-{startTile.Right}");
        if (Players[currentPlayerIndex].Hand.Count == 0)
        {
            EndGame();
            return;
        }
        currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;
        StateMachine.ChangeState(GameFlowState.TurnoJugador);
    }

    private int DetermineStartingPlayer()
    {
        int index = 0;
        DominoTile highestDouble = null;
        for (int i = 0; i < Players.Count; i++)
        {
            foreach (DominoTile t in Players[i].Hand)
            {
                if (t.Left == t.Right)
                {
                    if (highestDouble == null || t.Left > highestDouble.Left)
                    {
                        highestDouble = t;
                        index = i;
                    }
                }
            }
        }
        if (highestDouble != null)
            return index;

        DominoTile highest = null;
        for (int i = 0; i < Players.Count; i++)
        {
            foreach (DominoTile t in Players[i].Hand)
            {
                int val = t.Left + t.Right;
                if (highest == null || val > highest.Left + highest.Right)
                {
                    highest = t;
                    index = i;
                }
            }
        }
        return index;
    }

    private DominoTile ChooseStartingTile(Player player)
    {
        DominoTile highestDouble = null;
        foreach (DominoTile t in player.Hand)
        {
            if (t.Left == t.Right)
            {
                if (highestDouble == null || t.Left > highestDouble.Left)
                    highestDouble = t;
            }
        }
        if (highestDouble != null)
            return highestDouble;

        DominoTile highest = player.Hand[0];
        foreach (DominoTile t in player.Hand)
        {
            int val = t.Left + t.Right;
            if (val > highest.Left + highest.Right)
                highest = t;
        }
        return highest;
    }

    private void PlayTurn()
    {
        Player p = Players[currentPlayerIndex];
        DominoTile playable = null;
        bool placeLeft = true;
        foreach (DominoTile t in p.Hand)
        {
            if (Board.CanPlaceLeft(t))
            {
                playable = t;
                placeLeft = true;
                break;
            }
            if (Board.CanPlaceRight(t))
            {
                playable = t;
                placeLeft = false;
                break;
            }
        }

        if (playable != null)
        {
            p.PlayTile(playable, Board, placeLeft);
            Debug.Log($"{p.Name} juega {playable.Left}-{playable.Right}");
            passCount = 0;

            if (Board.LeftValue == Board.RightValue && Board.Tiles.Count > 1)
                Debug.Log("\u26a1 Capicua!");

            if (p.Hand.Count == 0)
            {
                EndGame();
                return;
            }
        }
        else
        {
            Debug.Log($"{p.Name} pasa");
            passCount++;
            if (passCount >= Players.Count)
            {
                Debug.Log("Trancada! Se cierra la ronda");
                EndGame();
                return;
            }
        }

        currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;
    }

    private void EndGame()
    {
        gameEnded = true;
        StateMachine.ChangeState(GameFlowState.FinRonda);
        Debug.Log("Fin de la partida");
    }
}
