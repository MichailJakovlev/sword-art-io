using System.Collections;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _coinShadowText;
    public int coins = 0;

    public void AddCoin()
    {
        coins++;
        int genericCoins = PlayerPrefs.GetInt("Coins");
        genericCoins += coins;
        PlayerPrefs.SetInt("Coins", genericCoins);
        StartCoroutine(CoinTextAnimation());
        _coinText.text = coins.ToString();
        _coinShadowText.text = _coinText.text;
    }

    public void ClearCoins()
    {
        coins = 0;
        _coinText.text = coins.ToString();
        _coinShadowText.text = _coinText.text;
    }

    private IEnumerator CoinTextAnimation()
    {
        for (int i = 0; i < 40; i++)
        {
            if (_coinText.fontSize < 70)
            {
                _coinText.fontSize += 0.5f;
                _coinShadowText.fontSize  += 0.5f;
            }
            
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 40; i++)
        {
            if (_coinShadowText.fontSize > 49)
            {
                _coinText.fontSize  -= 0.5f;
                _coinShadowText.fontSize  -= 0.5f;
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }
}
    