using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwordTimerUI : MonoBehaviour
{
    [SerializeField] private GameObject _swordSpeedTimer;
    [SerializeField] private Slider _swordSpeedSlider;
    
    void Start()
    {
        _swordSpeedTimer.SetActive(false);
    }
    
    public void StartSwordSpeedTimer()
    {
        _swordSpeedTimer.SetActive(true);
        _swordSpeedSlider.value = _swordSpeedSlider.maxValue;
        
        StopAllCoroutines();
        StartCoroutine(SwordTimerRoutine());
    }
    
    public IEnumerator SwordTimerRoutine()
    {
        while (_swordSpeedSlider.value != 0)
        {
            _swordSpeedSlider.value -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        
        _swordSpeedTimer.SetActive(false);
    }
}