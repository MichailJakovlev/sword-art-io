using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private Animations _animations;
    private SpriteRenderer _spriteRenderer;
    private bool _isNotCoursorEntered = true;

    private void Start()
    {
        _animations = GetComponent<Animations>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animations.Move(false);
    }

    void Update()
    {
        MoveToCursor();
        _spriteRenderer.flipX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x;
    }

    void MoveToCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        if (_isNotCoursorEntered)
        {
            Vector2 targetPosition = new(mousePosition.x, mousePosition.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void OnMouseEnter()
    {
        _isNotCoursorEntered = false;
        transform.position = transform.position;
        _animations.Idle();
    }

    private void OnMouseExit()
    {
        _isNotCoursorEntered = true;
        _animations.Move(false);
    }
}
