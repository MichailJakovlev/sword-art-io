using System.Collections;
using UnityEngine;
using Zenject;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthValue;
    
    private int _maxHealthValue;
    private EnemyPool _enemyPool;
    private Animations _animations;

    private void Awake()
    {
        _maxHealthValue = _healthValue;
        _animations = GetComponent<Animations>();

    }

    public void TakeDamage()
    {
        _healthValue -= 1;

        if (_healthValue <= 0)
        {
            _animations.Death();
          //  _enemyPool.Realize(gameObject);
           // _healthValue = _maxHealthValue;
        }
        else
        {
            _animations.Hit();
        }  
    }

    public void GetHeal(int healPointValue)
    {
        if (_healthValue + healPointValue < _maxHealthValue)
        {
            _healthValue += healPointValue;
        }
        else
        {
            _healthValue = _maxHealthValue;
        }
    }
}
