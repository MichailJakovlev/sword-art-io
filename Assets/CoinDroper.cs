using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDroper : MonoBehaviour
{
    [SerializeField] private List<Coin> coins;
    [SerializeField] private GameObject enemy;
    
    public void Drop()
    {
        transform.parent = null;
        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].gameObject.SetActive(Random.value < 0.5f);
        }
        
        StartCoroutine(LifeTimer());
    }

    private IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(10f);
        transform.parent = enemy.transform;
        gameObject.transform.position = enemy.transform.position;
        gameObject.SetActive(false);
    }
}
