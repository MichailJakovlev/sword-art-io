using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemPool _itemPool;

    private void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.layerOverridePriority == 2)
        {
            _itemPool.Realize(gameObject);
            collision.gameObject.GetComponentInChildren<SwordPool>().Get();
        }
    }
}
