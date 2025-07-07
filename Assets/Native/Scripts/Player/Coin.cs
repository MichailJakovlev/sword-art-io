using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    private CoinCounter _coinCounter;
    
    private AudioData _audioData;
    
    [Inject]
    private void Construct(AudioData audioData)
    {
        _audioData = audioData;
    }

    void Start()
    {
        _coinCounter = FindObjectOfType<CoinCounter>();
        _audioData = FindObjectOfType<AudioData>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.layerOverridePriority == 2)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (_audioData != null)
                {
                    _audioData.coinSound.pitch = Random.Range(0.9f, 1.1f);
                    _audioData.coinSound.Play();
                }
                _coinCounter.AddCoin();
            }
            gameObject.SetActive(false);
        }
    }
}
