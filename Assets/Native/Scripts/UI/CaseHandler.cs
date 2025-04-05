using UnityEngine;
using Zenject;

public class CaseHandler : MonoBehaviour
{
    private ICaseOpener _caseOpener;
    [SerializeField] private CanvasGroup _openCaseArea;



    [Inject]
    private void Cunstruct(ICaseOpener caseOpener)
    {
        _caseOpener = caseOpener;
    }
    public void OpenCase()
    {
        _caseOpener.CaseOpener.OpenCase();
    }
    public void SetAlpha()
    {
        _openCaseArea = GameObject.Find("Open Case Area").GetComponent<CanvasGroup>();
        _openCaseArea.alpha = 1;
    }
}
