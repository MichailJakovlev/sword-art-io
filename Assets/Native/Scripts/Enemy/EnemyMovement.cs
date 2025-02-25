using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Animations _animations;
    private SpriteRenderer _spriteRenderer;
    

    private Vector3 _targetPosition;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animations = GetComponent<Animations>();

        _spriteRenderer.transform.rotation = new Quaternion(45, 0, 0, 90);
        _targetPosition = new(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        _animations.Move();
    }

    void Update()
    {
        if (transform.position.x == _targetPosition.x && transform.position.z == _targetPosition.z)
        {
            _targetPosition = new(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
        _spriteRenderer.flipX = _targetPosition.x < transform.position.x;
    }
}
