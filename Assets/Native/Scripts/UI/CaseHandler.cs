using UnityEngine;
using Zenject;

public class CaseHandler : MonoBehaviour
{
    private ICaseOpener _caseOpener;


    [Inject]
    private void Cunstruct(ICaseOpener caseOpener)
    {
        _caseOpener = caseOpener;
    }
    public void OpenCase()
    {
        _caseOpener.OpenCase();
    }
}
