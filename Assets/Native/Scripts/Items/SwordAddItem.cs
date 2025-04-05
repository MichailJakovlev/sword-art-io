using UnityEngine;

public class SwordAddItem : MonoBehaviour, IItem
{
    GameObject IItem.GameObject => this.gameObject;
    private ItemPool _itemPool;

    private void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.layerOverridePriority == 2)
        {
            Effect(collision.gameObject);
        }
    }

    public void Effect(GameObject entity)
    {
        _itemPool.Realize(gameObject);
        entity.gameObject.GetComponentInChildren<SwordPool>().Get();
    }
}
