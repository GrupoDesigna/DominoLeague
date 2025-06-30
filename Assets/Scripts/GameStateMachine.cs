using UnityEngine;

public enum GameFlowState
{
    Reparto,
    TurnoJugador,
    FinRonda,
    FinPartida
}

public class GameStateMachine
{
    public GameFlowState CurrentState { get; private set; } = GameFlowState.Reparto;

    public delegate void StateChangeHandler(GameFlowState newState);
    public event StateChangeHandler OnStateChanged;

    public void ChangeState(GameFlowState newState)
    {
        if (CurrentState == newState)
            return;

        CurrentState = newState;
        OnStateChanged?.Invoke(CurrentState);
    }
}
