using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScoreCounter : MonoBehaviour
{
    public Dictionary<string, int> score = new Dictionary<string, int>();
    private Enemy _enemy;
    
    void Start()
    {
        for (int i = 0; i < EnemyPool.enemyArray.Length; i++)
        {
            _enemy = EnemyPool.enemyArray[i].GetComponent<Enemy>();
            var name = (EnemyNames)i;
            _enemy.name = name.ToString();
            _enemy.score = Random.Range(0, 100);
            score.Add(_enemy.name, _enemy.score);
        }
        
        var sortedScore = score.OrderByDescending(x => x.Value);
        foreach (var VARIABLE in sortedScore)
        {
            Debug.Log(VARIABLE.Key + " : " + VARIABLE.Value);
        }
    }
}
