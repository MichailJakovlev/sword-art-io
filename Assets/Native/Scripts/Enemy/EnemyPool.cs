using UnityEngine;

public class EnemyPool : MonoBehaviour, IEnemyPool
{
    EnemyPool IEnemyPool.EnemyPool => this;

    [SerializeField] private GameObject _enemy;
    [SerializeField] private SwordPool _swordPool;
    
    public static GameObject[] enemyArray;
    public static SwordPool[] swordPullArray;
   
    void Start()
    {
        enemyArray = new GameObject[GameData.EnemyAmount];
        swordPullArray = new SwordPool[GameData.EnemyAmount];
        Create();
    }

    public void Create()
    {
        for (int i = 0; i < GameData.EnemyAmount; i++)
        {
            enemyArray[i] = Instantiate(_enemy, PositionChanger(), Quaternion.identity, gameObject.transform);
            swordPullArray[i] = Instantiate(_swordPool, enemyArray[i].transform.position, Quaternion.identity, enemyArray[i].transform);
        }
    }

    public Vector3 PositionChanger()
    {
        Vector3 enemyPosition;

        enemyPosition.x = Random.Range(GameData.X * -1, GameData.X);
        enemyPosition.z = Random.Range(GameData.Z * -1, GameData.Z);
        enemyPosition.y = 0;

        return enemyPosition;
    }

    public void Get(GameObject enemy)
    {  
        enemy.GetComponent<Health>().GetHeal(10);
        enemy.transform.position = PositionChanger();
        enemy.GetComponentInChildren<SpriteRenderer>().enabled = true;
        enemy.GetComponent<EnemyMovement>().enabled = true;
        enemy.GetComponent<Collider>().enabled = true;
        enemy.GetComponent<Animations>().Move();
        SwordPool swordPool = enemy.GetComponentInChildren<SwordPool>();
        swordPool.enabled = true;
        swordPool.Get();
        enemy.transform.position = PositionChanger();
    }
}
