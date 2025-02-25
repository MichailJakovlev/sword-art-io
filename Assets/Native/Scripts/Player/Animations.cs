using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator _animator;
    private EnemyPool _enemyPool;
    private EnemyMovement _enemyMovement;
    private Collider _collider;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _enemyPool = GetComponentInParent<EnemyPool>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _collider = GetComponent<Collider>();
    }

    public void Move()
    {
        _animator.Play("Move");
    }

    public void Hit()
    {
        StopAllCoroutines();
        StartCoroutine(HitAnim());
    }

    public void Idle()
    {
        _animator.Play("Idle");
    }

    public void Death()
    {
        StopAllCoroutines();
        StartCoroutine(DeathAnim());
    }

    private IEnumerator DeathAnim()
    {
        _collider.enabled = false;
        _enemyMovement.enabled = false;
        _animator.Play("Death");
        yield return new WaitForSeconds(0.6f);
        _enemyPool.Realize(gameObject);
        _enemyMovement.enabled = true;
        _collider.enabled = true;
    }

    private IEnumerator HitAnim()
    {
        _animator.Play("Hit");
        yield return new WaitForSeconds(0.25f);
        _animator.Play("Move");
    }

    private IEnumerator IdleAnim()
    {
        _animator.Play("Idle");
        yield return new WaitUntil(() => _animator.GetBool("IsMove"));
    }
}

