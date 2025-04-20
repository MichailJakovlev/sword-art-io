using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveTimerUI : MonoBehaviour
{
    [SerializeField] private GameObject _moveSpeedTimer;
    [SerializeField] private Slider _moveSpeedSlider;
        
    void Start()
    {
        _moveSpeedTimer.SetActive(false);
    }

    public void StartMoveSpeedTimer()
    {
        _moveSpeedTimer.SetActive(true);
        _moveSpeedSlider.value = _moveSpeedSlider.maxValue;
        
        StopAllCoroutines();
        StartCoroutine(MoveTimerRoutine());
    }
    
    public IEnumerator MoveTimerRoutine()
    {
        while (_moveSpeedSlider.value != 0)
        {
            _moveSpeedSlider.value -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        
        _moveSpeedTimer.SetActive(false);
    }
}
