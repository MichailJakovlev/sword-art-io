using System.Collections;
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

    private GameObject[] enemyArray;
    private SwordPool[] swordPullArray;
    private bool _isTimerNotActive = true;

    void Start()
    {
        enemyArray = new GameObject[_enemyCount];
        swordPullArray = new SwordPool[_enemyCount];

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

    public Vector2 PositionChanger()
    {
        Vector2 enemyPosition;

        enemyPosition.x = Random.Range(_spawnAreaSizeX * -1, _spawnAreaSizeX);
        enemyPosition.y = Random.Range(_spawnAreaSizeY * -1, _spawnAreaSizeY);

        return enemyPosition;
    }

    public void Get(GameObject enemy)
    {  
        enemy.GetComponent<Health>().GetHeal(10);
        enemy.transform.position = PositionChanger();
        enemy.SetActive(true);
        enemy.GetComponent<Animations>().Move(false);
        enemy.GetComponentInChildren<SwordPool>().Get();
    }

    public void Realize(GameObject enemy)
    {
        enemy.SetActive(false);
        Get(enemy);
        // if (_isTimerNotActive)
        // {
        //   _isTimerNotActive = false;
        // StartCoroutine(Timer(enemy));
        // }
    }
    
    private IEnumerator Timer(GameObject enemy)
    {
        yield return new WaitForSeconds(3);
        Get(enemy);
        _isTimerNotActive = true;
    }
}
