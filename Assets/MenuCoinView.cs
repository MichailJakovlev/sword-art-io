using TMPro;
using UnityEngine;

public class MenuCoinView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinText;
    [SerializeField] TextMeshProUGUI _coinShadowText;
    public void Awake()
    {
        UpdateCoins();
    }

    public void UpdateCoins()
    {
        _coinText.text = PlayerPrefs.GetInt("Coins").ToString();
        _coinShadowText.text = _coinText.text;
    }
}
