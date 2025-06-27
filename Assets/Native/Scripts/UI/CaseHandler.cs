using UnityEngine;
using Zenject;

public class CaseHandler : MonoBehaviour
{
    private ICaseOpener _caseOpener;
    private CanvasGroup _openCaseArea;
    public CaseOpenAnimation _caseOpenAnimation;
    public CaseScreeen _caseScreeen;
    
    [Inject]
    private void Cunstruct(ICaseOpener caseOpener)
    {
        _caseOpener = caseOpener;
    }

    public void AddMoney()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins");
        currentCoins += 1000;
        PlayerPrefs.SetInt("Coins", currentCoins);
    }
    
    public void OpenCase()
    {
        if(PlayerPrefs.GetInt("Coins") >= 100) 
        {
            _caseOpener.CaseOpener.OpenCase();
            int currentCoins = PlayerPrefs.GetInt("Coins");
            currentCoins -= 100;
            PlayerPrefs.SetInt("Coins", currentCoins);
        }
    }
    
    public void SetAlpha(int alpha)
    {
        _openCaseArea = GameObject.Find("Open Case Area").GetComponent<CanvasGroup>();
        _openCaseArea.alpha = alpha;
    }
}
