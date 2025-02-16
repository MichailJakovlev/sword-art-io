using UnityEngine;

public class HealItem : MonoBehaviour
{
    private ItemPool _itemPool;
    [SerializeField] private int _healPointValue;

    private void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.layerOverridePriority == 0)
        {
            _itemPool.Realize(gameObject);
            collision.gameObject.GetComponentInChildren<Health>().GetHeal(_healPointValue);
        }
    }
}