using UnityEngine;

public class Health : MonoBehaviour
{
    public int _healthValue;
    public int _maxHealthValue;
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
