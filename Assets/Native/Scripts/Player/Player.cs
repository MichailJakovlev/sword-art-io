using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer, IScorable
{
    private Player _player;
    Player IPlayer.Player => this;
    public GameObject GameObject => gameObject;
    private Health _health;
    private SwordPool _swordPool;
    public int score { get; set; }

    private void Start()
    {
        _health = GetComponent<Health>();
        _swordPool = GetComponentInChildren<SwordPool>();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new (0,0,0), new (GameData.X * 2, 0, GameData.Z * 2));
    }

    public void Death()
    {
        _swordPool.RealizeAll();
        Respawn();
    }

    public void Respawn()
    {
        _health._healthValue = _health._maxHealthValue;
        transform.position = new Vector3(UnityEngine.Random.Range(GameData.X * -1 + 15, GameData.X - 15), 0, UnityEngine.Random.Range(GameData.Z * -1 + 15, GameData.Z - 15));
        _swordPool.Get();
    }
}
