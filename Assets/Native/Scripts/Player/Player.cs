using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private Player _player;
    Player IPlayer.Player => this;
    public GameObject GameObject => gameObject;
}
