using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Animations _animations;
    private SpriteRenderer _spriteRenderer;
    private NavMeshAgent _navMeshAgent;
    public Vector3 _targetPosition;
    public float _moveSpeed;
    
    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animations = GetComponent<Animations>();
        _spriteRenderer.transform.rotation = new Quaternion(45, 0, 0, 90);
        _animations.Move();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false; 
        _navMeshAgent.speed = _moveSpeed;
    }
    
    void FixedUpdate()
    {
        Vector3 lastPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.fixedDeltaTime);
        
        if (transform.position.x == _targetPosition.x && transform.position.z == _targetPosition.z || lastPosition.x == transform.position.x && lastPosition.z == transform.position.z)
        { 
            _targetPosition = new Vector3(Random.Range((GameData.X - 5) * -1, GameData.X - 5), 0, Random.Range((GameData.Z - 5) * -1, GameData.Z - 5));
        }
        
        _spriteRenderer.flipX = _targetPosition.x < transform.position.x; 
    }
}
 