using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator _animator;
    private Enemy _enemy;
    private EnemyMovement _enemyMovement;
    private Collider _collider;
    

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<Collider>();
        
        if (gameObject.tag != "Player")
        {
            _enemy = GetComponent<Enemy>();
            _enemyMovement = GetComponent<EnemyMovement>();
            
        }
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
        if (gameObject.tag != "Player")
        {
            _collider.enabled = false;
            _enemyMovement.enabled = false;
           // _swordPool.enabled = false;
        }
        
        _animator.Play("Death");
        
        yield return new WaitForSeconds(0.6f);
        _enemy.Realize();
    }

    private IEnumerator HitAnim()
    {
        _animator.Play("Hit");
        yield return new WaitForSeconds(0.25f);
        _animator.Play("Move");
    }
}

