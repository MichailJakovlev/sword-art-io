using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IScorable
{
    private EnemyPool _enemyPool;
    private SpriteRenderer _spriteRenderer;
    private SwordPool _swordPool;
    public int score { get; set; }
    
    private void Start()
    {
        _enemyPool = GetComponentInParent<EnemyPool>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordPool = GetComponentInChildren<SwordPool>();
    }

    public void Realize()
    {
        _spriteRenderer.enabled = false;
        _swordPool.RealizeAll();
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        _enemyPool.Get(gameObject);
    }
}
