using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DominoBoard Board;
    public List<Player> Players = new List<Player>();
    public GameStateMachine StateMachine = new GameStateMachine();

    private void Start()
    {
        Players.Add(new Player("Player 1"));
        Players.Add(new Player("Player 2"));

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
}
