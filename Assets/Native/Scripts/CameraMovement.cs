using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    private IPlayer _player;

    [Inject]
    private void Construct(IPlayer player)
    {
        _player = player;
    }

    private void Start()
    {
        transform.parent = _player.Player.transform;
    }
}
