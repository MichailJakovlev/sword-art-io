using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Health : MonoBehaviour
{
    public Slider _healthSlider;
    public int _healthValue;
    public int _maxHealthValue;
    private Animations _animations;
    private IScorable _scorable;
    private ScoreView _scoreView;
    private GameOverMenu _gameOverMenu;
    
    private AudioData _audioData;
    
    [Inject]
    private void Construct(AudioData audioData)
    {
        _audioData = audioData;
    }

    private void Awake()
    {
        _scoreView = FindObjectOfType<ScoreView>();
        _maxHealthValue = _healthValue;
        _healthSlider.maxValue = _maxHealthValue;
        _healthSlider.value = _maxHealthValue;
        _animations = GetComponent<Animations>();
        _scorable = GetComponent<IScorable>();
        _gameOverMenu = FindFirstObjectByType<GameOverMenu>();
        _audioData = FindFirstObjectByType<AudioData>();
    }
    
    public void TakeDamage()
    {
        _healthValue -= 1;
        _healthSlider.value = _healthValue;

        if (gameObject.tag == "Player")
        {
            if (_audioData != null)
            {
                _audioData.hitSound.pitch = Random.Range(0.9f, 1.1f);
                _audioData?.hitSound.Play();
            }
        }
        
        if (_healthValue <= 0)
        {
            _animations.Death();

            if (gameObject.tag == "Player")
            {
                if (_scorable.score >= PlayerPrefs.GetInt("playerScoreRecord"))
                {
                    PlayerPrefs.SetInt("playerScoreRecord", _scorable.score);
                }
                _gameOverMenu.Show(_scorable.score);
                
            }
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
        _healthSlider.value = _healthValue;
    }
}
