using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemPool _itemPool;

    private void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.layerOverridePriority == 0)
        {
            _itemPool.Realize(gameObject);
            collision.gameObject.GetComponentInChildren<SwordPool>().Get();
        }
    }
}
