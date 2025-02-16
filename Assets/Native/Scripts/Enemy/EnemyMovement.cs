using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Animator _animator;
    private Animations _animations;
    private SpriteRenderer _spriteRenderer;

    private Vector2 _targetPosition;

    private void Start()
    {
        _animations = GetComponent<Animations>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _targetPosition = new(Random.Range(-10, 10), Random.Range(-10, 10));
        _animations.Move(false);
    }

    void Update()
    {
        if (transform.position.x == _targetPosition.x && transform.position.y == _targetPosition.y)
        {
            _targetPosition = new(Random.Range(-10, 10), Random.Range(-10, 10));
        }
        
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
        _spriteRenderer.flipX = _targetPosition.x < transform.position.x;
    }
}
