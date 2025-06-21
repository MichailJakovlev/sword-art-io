using System.Collections;
using UnityEngine;

public class LoadingTimer : MonoBehaviour
{
    [SerializeField] private GameObject _loadingPage;
    [SerializeField] private UIHandler _uiHandler;

    public void StartLoading()
    {
        _loadingPage.SetActive(true);
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        _uiHandler.ToGameScene();
    }
}
