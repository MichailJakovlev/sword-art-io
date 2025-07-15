using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    [SerializeField] private List<Sprite> _coinSprites;
    [SerializeField] private SpriteRenderer _coinIcon;
    
    private CoinCounter _coinCounter;
    private AudioData _audioData;
    private int _coinValue;
    
    [Inject]
    private void Construct(AudioData audioData)
    {
        _audioData = audioData;
    }

    void Start()
    {
        _coinCounter = FindObjectOfType<CoinCounter>();
        _audioData = FindObjectOfType<AudioData>();

        ReshuffleCoin();
    }

    void ReshuffleCoin()
    {
        switch (Random.Range(0,3))
        {
            case 0:
                _coinIcon.sprite = _coinSprites[0];
                _coinValue = 1;
                break;
            case 1: 
                _coinIcon.sprite = _coinSprites[1];
                _coinValue = 3;
                break;
            case 2: 
                _coinIcon.sprite = _coinSprites[2];
                _coinValue = 5;
                break;
        }
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
                _coinCounter.AddCoin(_coinValue);
                ReshuffleCoin();
            }
            gameObject.SetActive(false);
        }
    }
}
 