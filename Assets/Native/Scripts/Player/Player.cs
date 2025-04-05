using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private Player _player;
    Player IPlayer.Player => this;
    public GameObject GameObject => gameObject;


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new (0,0,0), new (GameData.X * 2, 0, GameData.Z * 2));
    }
}
