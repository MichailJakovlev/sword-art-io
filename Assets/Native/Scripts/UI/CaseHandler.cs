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
    
    public void OpenCase()
    {
        _caseOpener.CaseOpener.OpenCase();
    }
    
    public void SetAlpha(int alpha)
    {
        _openCaseArea = GameObject.Find("Open Case Area").GetComponent<CanvasGroup>();
        _openCaseArea.alpha = alpha;
    }
}
