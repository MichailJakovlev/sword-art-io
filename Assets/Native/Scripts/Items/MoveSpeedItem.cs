using UnityEngine;

public class MoveSpeedItem : MonoBehaviour, IItem
{
    [SerializeField] private PlayerMovement _playerMovement;

    GameObject IItem.GameObject => this.gameObject;

    private ItemPool _itemPool;
    private float _buffSpeed;

    public void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
        _buffSpeed = _playerMovement._moveSpeed * 2f;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.layerOverridePriority == 2)
        {
            Effect(collision.gameObject);
        }
    }

    public void Effect(GameObject entity)
    {
        _itemPool.Realize(gameObject);
        entity.GetComponent<MoveSpeedBuffTimer>().StartBuffTimer(_buffSpeed / 2);
    }
}
