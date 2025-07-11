using UnityEngine;
using Zenject;

public class CaseHandler : MonoBehaviour
{
    private ICaseOpener _caseOpener;
    private CanvasGroup _openCaseArea;
    public CaseOpenAnimation _caseOpenAnimation;
    public CaseScreeen _caseScreeen;
    public MenuCoinView _menuCoinView;
    private GameConfig _gameConfig;
    
    [Inject]
    private void Cunstruct(ICaseOpener caseOpener, GameConfig gameConfig)
    {
        _caseOpener = caseOpener;
        _gameConfig = gameConfig;
    }
    
    public void OpenCase()
    {
        // if(PlayerPrefs.GetInt("Coins") >= 100) 
        if(PlayerPrefs.GetInt("Coins") >= 0) 
        {
            _caseOpener.CaseOpener.OpenCase();
            int currentCoins = PlayerPrefs.GetInt("Coins");
            // currentCoins -= 100;
            PlayerPrefs.SetInt("Coins", currentCoins);
            _menuCoinView.UpdateCoins();
        }
    }

    public void ReturnCoins()
    { 
        var skinLotCurrent = _gameConfig.SkinsSO.skinInfo.Find(skin => _caseOpener.CaseOpener.currentSkinLotName == skin.name.ToString());
        var rarityInfo = _gameConfig.RaritySO.rarityInfo.Find(rarity => rarity.skinsRarity == skinLotCurrent.skinsRarity);
        
        int currentCoins = PlayerPrefs.GetInt("Coins");
        currentCoins += rarityInfo.cost;
        PlayerPrefs.SetInt("Coins", currentCoins);
        _menuCoinView.UpdateCoins();
    }
    
    public void SetAlpha(int alpha)
    {
        _openCaseArea = GameObject.Find("Open Case Area").GetComponent<CanvasGroup>();
        _openCaseArea.alpha = alpha;
    }
}
