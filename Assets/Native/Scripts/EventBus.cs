using System;
using UnityEngine;

public class EventBus : MonoBehaviour , IEventBus
{
    private IEventBus _eventBus;
    EventBus IEventBus.EventBus => this;

    public static event Action StartGame;
    public static event Action StopGame;
    public static event Action<int> AuthPlayer;

    public void StartGameEvent() => StartGame?.Invoke();
    public void StopGameEvent() => StopGame?.Invoke();
    public void AuthPlayerEvent(int authPlayerStatus) => AuthPlayer?.Invoke(authPlayerStatus);
}
