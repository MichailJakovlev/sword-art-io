using System.Runtime.InteropServices;
using UnityEngine;

public class ReadyGameAPI : MonoBehaviour, IReadyGameAPI
{
    [DllImport("__Internal")]
    public static extern void SendGameReady();

    [DllImport("__Internal")]
    public static extern void SendGameStart();

    [DllImport("__Internal")]
    public static extern void SendGameStop();

    private IReadyGameAPI _readyGameAPI;
    ReadyGameAPI IReadyGameAPI.ReadyGameAPI => this;

    private void OnEnable()
    {
        EventBus.StopGame += StopGame;
        EventBus.StartGame += StartGame;
    }

    private void OnDisable()
    {
        EventBus.StopGame -= StopGame;
        EventBus.StartGame -= StartGame;
    }

    public void Start()
    {
      //  ReadyGame();
    }

    public void ReadyGame()
    {
        SendGameReady();
        StartGame();
    }

    public void StartGame()
    {
        SendGameStart();
    }

    public void StopGame()
    {
        SendGameStop();
    }
}
