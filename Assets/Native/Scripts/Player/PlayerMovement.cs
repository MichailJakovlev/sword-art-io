using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private Animations _animations;
    private SpriteRenderer _spriteRenderer;
    private float _horizontal, _vertical;
    private Vector3 targetPosition;

    private void Start()
    {
        _animations = GetComponent<Animations>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.transform.rotation = new Quaternion(45, 0, 0, 90);
        
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        MovePlayer();
    }

    void MovePlayer()
    {
        targetPosition = new Vector3(_horizontal, 0, _vertical).normalized;

        if (targetPosition.magnitude != 0)
        {
            _spriteRenderer.flipX = _horizontal < 0;
            _animations.Move();
        }
        else
        {   
            _animations.Idle();
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + targetPosition, moveSpeed * Time.deltaTime);
    }
}
