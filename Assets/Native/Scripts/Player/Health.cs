using UnityEngine;

public class Health : MonoBehaviour
{
    public int _healthValue;
    public int _maxHealthValue;
    private Animations _animations;
    private IScorable _scorable;
    private ScoreView _scoreView;

    private void Awake()
    {
        _scoreView = FindObjectOfType<ScoreView>();
        _maxHealthValue = _healthValue;
        _animations = GetComponent<Animations>();
        _scorable = GetComponent<IScorable>();
    }

    public void TakeDamage()
    {
        _healthValue -= 1;
        
        if (_healthValue <= 0)
        {
            _animations.Death();
            
            _scorable.score = 0;
            _scoreView.score[_scorable.name] = _scorable.score;
            
            _scoreView.ViewScore();
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
