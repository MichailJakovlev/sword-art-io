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
    
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(_player.GameObject.transform.position.x, GameData.X * -1 + 10, GameData.X - 10),
            5,
            Mathf.Clamp(_player.GameObject.transform.position.z - 5, GameData.Z * -1 - 10, GameData.Z - 10));
    }
}
