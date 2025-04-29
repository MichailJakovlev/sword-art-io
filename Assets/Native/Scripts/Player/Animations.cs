using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator _animator;
    private Enemy _enemy;
    private EnemyMovement _enemyMovement;
    private Collider _collider;
    private Player _player;
    private bool isAnimationBusy = false;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<Collider>();
        
        if (gameObject.tag != "Player")
        {
            _enemy = GetComponent<Enemy>();
            _enemyMovement = GetComponent<EnemyMovement>();
            
        }
        else
        {
            _player = GetComponent<Player>();
        }
    }

    public void Move()  
    {
        if (isAnimationBusy == false)
        {
            _animator.Play("Move");
        }
    }

    public void Hit()
    {
        isAnimationBusy = true;
        StopAllCoroutines();
        StartCoroutine(HitAnim());
    }

    public void Idle()
    {
        if (isAnimationBusy == false)
        {
            _animator.Play("Idle");
        }
    }

    public void Death()
    {
        isAnimationBusy = true;
        StopAllCoroutines();
        StartCoroutine(DeathAnim());
    }

    private IEnumerator DeathAnim()
    {
        if (gameObject.tag != "Player")
        {
            _collider.enabled = false;
            _enemyMovement.enabled = false;
        }
        
        _animator.Play("Death");
        
        yield return new WaitForSeconds(0.6f);
        _player?.Death();
        _enemy?.Realize();
        isAnimationBusy = false;
    }

    private IEnumerator HitAnim()
    {
        _animator.Play("Hit");
        yield return new WaitForSeconds(0.25f);
        _animator.Play("Move");
        isAnimationBusy = false;
    }
}

