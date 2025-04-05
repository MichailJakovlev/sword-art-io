using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyPool _enemyPool;
    private SpriteRenderer _spriteRenderer;
    private SwordPool _swordPool;

    private void Start()
    {
        _enemyPool = GetComponentInParent<EnemyPool>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordPool = GetComponentInChildren<SwordPool>();
    }

    public void Realize()
    {
        _spriteRenderer.enabled = false;
        _swordPool.enabled = false;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        _enemyPool.Get(gameObject);
    }
}
