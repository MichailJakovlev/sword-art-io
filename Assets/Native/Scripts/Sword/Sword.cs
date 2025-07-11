using UnityEngine;
using Zenject;

public class Sword : MonoBehaviour
{
    private SwordPool _swordPull;
    private IScorable _scorable;
    private Health _enemyHealth;
    private ScoreView _scoreView;
    private ParticleSystem _particleSystem;
    private AudioData _audioData;
    private Chest _chest;

    private void Awake()
    {
        _scoreView = FindObjectOfType<ScoreView>();
        _swordPull = GetComponentInParent<SwordPool>();
        _scorable = GetComponentInParent<IScorable>();
        _particleSystem = GetComponentInParent<ParticleSystem>();
        _chest = FindFirstObjectByType<Chest>();
        if(_swordPull.transform.parent.tag == "Player")
        {
            _audioData = FindFirstObjectByType<AudioData>();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.layerOverridePriority == 3)
        {
            _particleSystem.Play();
            _swordPull.Realize(gameObject);
            _audioData.swordBreakSound.pitch = Random.Range(0.9f, 1.1f);
            _audioData.swordBreakSound.Play();
        }
        else if(collision.collider.layerOverridePriority == 2)
        { 
            _enemyHealth = collision.gameObject.GetComponent<Health>();
           
            if (_enemyHealth._healthValue == 1)
            {
                _scorable.score++;
                _scoreView.score[_scorable.name] = _scorable.score;
            }
            if (_audioData != null)
            {
                _audioData.hitSound.pitch = Random.Range(0.9f, 1.1f);
                _audioData?.hitSound.Play();
            }
            _enemyHealth.TakeDamage();
        }
        else if (collision.collider.layerOverridePriority == 5)
        {
            if (_audioData != null)
            { 
                _chest.PlayAudio();
            }
        }
    }
}
