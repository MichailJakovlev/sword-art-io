using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyPool : MonoBehaviour, IEnemyPool
{
    EnemyPool IEnemyPool.EnemyPool => this;

    [SerializeField] private GameObject _enemy;
    [SerializeField] private SwordPool _swordPool;
    [SerializeField] private int _enemyCount;
    [SerializeField] private int _spawnAreaSizeX;
    [SerializeField] private int _spawnAreaSizeY;

    private Queue<GameObject> _respawnQueue;
    private GameObject[] enemyArray;
    private SwordPool[] swordPullArray;
    private bool _isTimerNotActive = true;

    void Start()
    {
        enemyArray = new GameObject[_enemyCount];
        swordPullArray = new SwordPool[_enemyCount];
        _respawnQueue = new Queue<GameObject>();

        Create();
    }

    public void Create()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            enemyArray[i] = Instantiate(_enemy, PositionChanger(), Quaternion.identity, gameObject.transform);
            swordPullArray[i] = Instantiate(_swordPool, enemyArray[i].transform.position, Quaternion.identity, enemyArray[i].transform);
        }
    }

    public Vector3 PositionChanger()
    {
        Vector3 enemyPosition;

        enemyPosition.x = Random.Range(_spawnAreaSizeX * -1, _spawnAreaSizeX);
        enemyPosition.z = Random.Range(_spawnAreaSizeY * -1, _spawnAreaSizeY);
        enemyPosition.y = 0;

        return enemyPosition;
    }

    public void Get(GameObject enemy)
    {  
        enemy.GetComponent<Health>().GetHeal(10);
        enemy.transform.position = PositionChanger();
        enemy.SetActive(true);
        enemy.GetComponent<Animations>().Move();
        enemy.GetComponentInChildren<SwordPool>().Get();
    }

    public void Realize(GameObject enemy)
    {
        enemy.SetActive(false);
        _respawnQueue.Enqueue(enemy);

        if (_isTimerNotActive)
        {
            _isTimerNotActive = false;
            StartCoroutine(Timer());
        }
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        GameObject enemy = _respawnQueue.Dequeue();
        Get(enemy);
        _isTimerNotActive = true;
    }
}
