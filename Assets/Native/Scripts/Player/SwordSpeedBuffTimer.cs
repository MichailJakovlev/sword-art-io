using System.Collections;
using UnityEngine;

public class SwordSpeedBuffTimer : MonoBehaviour
{
    [SerializeField] private float _duration;

    public void StartBuffTimer(float originSpeed)
    {
        StopAllCoroutines();

        gameObject.GetComponentInChildren<SwordsRotate>()._swordsRotateSpeed = originSpeed * 2;

        StartCoroutine(BuffTimer(originSpeed));
    }

    public IEnumerator BuffTimer(float originSpeed)
    {
        yield return new WaitForSeconds(_duration);

        gameObject.GetComponentInChildren<SwordsRotate>()._swordsRotateSpeed = originSpeed;
    }
}
