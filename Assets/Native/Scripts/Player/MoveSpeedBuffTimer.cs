using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveSpeedBuffTimer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Image _moveTimeImage;

    public void StartBuffTimer(float originSpeed)
    {
        StopAllCoroutines();

        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<PlayerMovement>()._moveSpeed = originSpeed * 2;
        }
        else
        {
            gameObject.GetComponent<EnemyMovement>()._moveSpeed = originSpeed * 2;
        }

        StartCoroutine(BuffTimer(originSpeed));
    }

    public IEnumerator BuffTimer(float originSpeed)
    {
        yield return new WaitForSeconds(_duration);
        
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
