using UnityEngine;
using Zenject;

public class CombatDirector : MonoBehaviour
{
    [SerializeField] private int tickLimit;
    private EnemyMovement[] _enemyMovements;
    private IPlayer _player;
    private SwordPool _playerSwordPool;
    private int tickCounter;
    
    [Inject]
    private void Construct(IPlayer player)
    {
        _player = player;
    }
    private void Start()
    {
        _enemyMovements = new EnemyMovement[EnemyPool.enemyArray.Length];
        _playerSwordPool = _player.Player.GetComponentInChildren<SwordPool>();
        
        for (int i = 0; i < EnemyPool.enemyArray.Length; i++)
        {
            _enemyMovements[i] = EnemyPool.enemyArray[i].GetComponent<EnemyMovement>();
            _enemyMovements[i]._targetPosition = new Vector3(Random.Range((GameData.X - 5) * -1, GameData.X - 5), 0, Random.Range((GameData.Z - 5) * -1, GameData.Z - 5));
        }
    }

    void FixedUpdate()
    {
        if (tickCounter >= tickLimit)
        {
            SetTarget();  
            tickCounter = 0;
        }
        else
        {
            tickCounter++;
        }
    }
    
    private Vector3 EscapeBehaviour(GameObject entity , GameObject enemy)
    {
        // X axis edit
        float xAxis;
        if (enemy.transform.position.x < entity.transform.position.x)
        {
            xAxis = entity.transform.position.x + 1;
        }
        else
        {
            xAxis = entity.transform.position.x - 1;
        }
        
        // Z axis edit
        float zAxis;
        if (enemy.transform.position.z < entity.transform.position.z)
        {
            zAxis = entity.transform.position.z + 1;
        }
        else
        {
            zAxis = entity.transform.position.z - 1;
        }
        
        Vector3 _target = new Vector3(xAxis, 0, zAxis);
        
        if(_target.x > GameData.X || _target.z > GameData.Z || _target.x < GameData.X * -1 || _target.z < GameData.Z * -1)
        {
            _target = new Vector3(Random.Range((GameData.X - 5) * -1, GameData.X - 5), 0, Random.Range((GameData.Z - 5) * -1, GameData.Z - 5));
        }
        return _target;
    }
    
    public void SetTarget()
    {
        for (int i = 0; i < EnemyPool.swordPullArray.Length; i++)
        {
            for (int j = 0; j < EnemyPool.swordPullArray.Length; j++)
            {
                if(j != i)
                {
                    if (Vector3.Distance(EnemyPool.swordPullArray[i].transform.position, EnemyPool.swordPullArray[j].transform.position) < 10f)
                    {
                        if (EnemyPool.swordPullArray[i]._iterator < EnemyPool.swordPullArray[j]._iterator)
                        {
                            _enemyMovements[i]._targetPosition = EscapeBehaviour(EnemyPool.enemyArray[i], EnemyPool.enemyArray[j]);
                            _enemyMovements[j]._targetPosition = EnemyPool.enemyArray[i].transform.position;
                        }
                        else if(EnemyPool.swordPullArray[i]._iterator == EnemyPool.swordPullArray[j]._iterator)
                        {
                            _enemyMovements[i]._targetPosition = EscapeBehaviour(EnemyPool.enemyArray[i], EnemyPool.enemyArray[j]);
                            _enemyMovements[j]._targetPosition = EscapeBehaviour(EnemyPool.enemyArray[j], EnemyPool.enemyArray[i]);
                        }
                    }
                }
                else if(Vector3.Distance(EnemyPool.swordPullArray[i].transform.position, _player.Player.transform.position) < 10f)
                {
                    if (EnemyPool.swordPullArray[i]._iterator <= _playerSwordPool._iterator)
                    {
                        _enemyMovements[i]._targetPosition = EscapeBehaviour(EnemyPool.enemyArray[i], _player.GameObject);
                    }
                    else
                    {
                        _enemyMovements[i]._targetPosition = _player.Player.transform.position;
                    }
                }
            }
            for (int j = 0; j < ItemPool.items.Length; j++)
            {
                if (Vector3.Distance(ItemPool.items[j].GameObject.transform.position, EnemyPool.enemyArray[i].transform.position) < 10f)
                {
                    _enemyMovements[i]._targetPosition = ItemPool.items[j].GameObject.transform.position;
                } 
            }
        }    
    }
}
