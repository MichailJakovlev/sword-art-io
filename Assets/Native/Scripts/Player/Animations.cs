using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator _animator;
    private EnemyPool _enemyPool;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _enemyPool = GetComponentInParent<EnemyPool>();
    }

    public void Move(bool hit)
    {
        StartCoroutine(Animate(hit));
    }

    public void Idle()
    {
        _animator.Play("Idle");
    }

    public void Death()
    {
        StopCoroutine(Animate(false));
        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        _animator.Play("Death");
        yield return new WaitForSeconds(0.6f);
        _enemyPool.Realize(gameObject);
    }

    private bool GetHit(bool hit)
    {
        if(hit)
        {
            return true;
        }
        return false;
    }

    private IEnumerator Animate(bool hit)
    {
        while(true)
        {
            _animator.Play("Move");

            yield return new WaitUntil(() => GetHit(hit));
            _animator.Play("Hit");
            hit = false;

            yield return new WaitForSeconds(0.05f);
            _animator.Play("Move");

            yield return new WaitUntil(() => GetHit(hit));
        }
    }
}

