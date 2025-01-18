using UnityEngine;

public class GameState : MonoBehaviour, IGameState
{
    private IGameState _gameState;
    GameState IGameState.GameState => this;

    private void OnEnable()
    {
        EventBus.StartGame += StartGame;
        EventBus.StopGame += StopGame;
    }

    private void OnDisable()
    {
        EventBus.StartGame -= StartGame;
        EventBus.StopGame -= StopGame;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
}
