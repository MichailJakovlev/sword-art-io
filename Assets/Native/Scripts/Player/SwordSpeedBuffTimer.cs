using System.Collections;
using UnityEngine;

public class SwordSpeedBuffTimer : MonoBehaviour
{
    private SwordTimerUI _timerUI;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            _timerUI = FindObjectOfType<SwordTimerUI>();
        }
    }
    
    public void StartBuffTimer(float originSpeed)
    {
        StopAllCoroutines();
        
        gameObject.GetComponentInChildren<SwordsRotate>()._swordsRotateSpeed = originSpeed * 2;

        StartCoroutine(BuffTimer(originSpeed));
        if (gameObject.tag == "Player")
        {
            _timerUI.StartSwordSpeedTimer();
        }
    }

    public IEnumerator BuffTimer(float originSpeed)
    {
        yield return new WaitForSeconds(GameData.BuffTime);

        gameObject.GetComponentInChildren<SwordsRotate>()._swordsRotateSpeed = originSpeed;
    }
}
