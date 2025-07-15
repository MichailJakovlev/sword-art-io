using TMPro;
using UnityEngine;

public class MenuCoinView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinText;
    [SerializeField] TextMeshProUGUI _coinShadowText;
    [SerializeField] private CaseScreeen _caseScreeen;
    public void OnEnable()
    {
        UpdateCoins();
    }

    public void UpdateCoins()
    {
        _coinText.text = PlayerPrefs.GetInt("Coins").ToString();
        _coinShadowText.text = _coinText.text;
        _caseScreeen.CheckCoins();
    }
}
