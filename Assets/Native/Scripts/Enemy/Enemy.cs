using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IScorable
{
    private EnemyPool _enemyPool;
    private SpriteRenderer _spriteRenderer;
    private SwordPool _swordPool;
    public GameObject _shadow;
    public GameObject _nameUI;
    public int score { get; set; }
    public string name { get; set; }
    
    private void Start()
    {
        _enemyPool = GetComponentInParent<EnemyPool>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordPool = GetComponentInChildren<SwordPool>();
    }

    public void Realize()
    {
        _nameUI.SetActive(false);
        _shadow.SetActive(false);
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
