using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinCounter _coinCounter;

    void Start()
    {
        _coinCounter = FindObjectOfType<CoinCounter>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.layerOverridePriority == 2)
        {
            if (collision.gameObject.tag == "Player")
            {
                _coinCounter.AddCoin();
            }
            gameObject.SetActive(false);
        }
    }
}
