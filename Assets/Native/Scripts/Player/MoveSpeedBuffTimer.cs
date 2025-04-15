using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveSpeedBuffTimer : MonoBehaviour
{
    private MoveTimerUI _timerUI;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            _timerUI = FindObjectOfType<MoveTimerUI>();
        }
    }
    
    public void StartBuffTimer(float originSpeed)
    {
        StopAllCoroutines();

        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<PlayerMovement>()._moveSpeed = originSpeed * 2;
            _timerUI.StartMoveSpeedTimer();
        }
        else
        {
            gameObject.GetComponent<EnemyMovement>()._moveSpeed = originSpeed * 2;
        }

        StartCoroutine(BuffTimer(originSpeed));
    }

    public IEnumerator BuffTimer(float originSpeed)
    {
        yield return new WaitForSeconds(GameData.BuffTime);
        
        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<PlayerMovement>()._moveSpeed = originSpeed;
        }
        else
        {
            gameObject.GetComponent<EnemyMovement>()._moveSpeed = originSpeed;
        }
    } 
}
