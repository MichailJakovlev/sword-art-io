using UnityEngine;

public class Sword : MonoBehaviour
{
    private SwordPool _swordPull;
    private IScorable _scorable;
    private Health _enemyHealth;
    private ScoreView _scoreView;

    private void Awake()
    {
        _scoreView = FindObjectOfType<ScoreView>();
        _swordPull = GetComponentInParent<SwordPool>();
        _scorable = GetComponentInParent<IScorable>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.layerOverridePriority == 3)
        {
            _swordPull.Realize(gameObject);
        }
        else if(collision.collider.layerOverridePriority == 2)
        { 
            _enemyHealth = collision.gameObject.GetComponent<Health>();
           
            if (_enemyHealth._healthValue == 1)
            {
                _scorable.score++;
                _scoreView.score[_scorable.name] = _scorable.score;
            }
            _enemyHealth.TakeDamage();
        }
    }  
}
