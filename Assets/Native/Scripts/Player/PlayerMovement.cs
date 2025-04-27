using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _moveSpeed;
    [SerializeField] private VariableJoystick _variableJoystick;
    
    private Animations _animations;
    private SpriteRenderer _spriteRenderer;
    private NavMeshAgent _navMeshAgent;
    private float _horizontal, _vertical;
    private bool _isMobilePlatform;
    private Vector3 targetPosition;
    
    private void Start()
    {
        _animations = GetComponent<Animations>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.transform.rotation = new Quaternion(45, 0, 0, 90);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.speed = _moveSpeed;
        
        if (Application.isMobilePlatform)
        {
            _variableJoystick = GameObject.Find("VariableJoystick").GetComponent<VariableJoystick>();
            _isMobilePlatform = true;
        }
        else
        {
            _isMobilePlatform = false;
        }
    }
    
    void Update()
    {
        if (_isMobilePlatform)
        {
            targetPosition = Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal; 
        }
        else
        {
            _horizontal = Input.GetAxisRaw("Horizontal"); 
            _vertical = Input.GetAxisRaw("Vertical");    
            targetPosition = new Vector3(_horizontal, 0, _vertical).normalized;
        }
        
        MovePlayer();
    }

    void MovePlayer()
    {
        if (targetPosition.magnitude != 0)
        {
            _spriteRenderer.flipX = targetPosition.x < 0;
            _animations.Move();
        }
        else
        {   
              _animations.Idle();
        }
        
        _navMeshAgent.velocity = targetPosition * _moveSpeed * Time.fixedDeltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, transform.position + targetPosition, _moveSpeed * Time.deltaTime);
    }
}
