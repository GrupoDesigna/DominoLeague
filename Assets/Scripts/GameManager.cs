using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DominoBoard Board;
    public List<Player> Players = new List<Player>();

    private void Start()
    {
        Players.Add(new Player("Player 1"));
        Players.Add(new Player("Player 2"));
    }
}
