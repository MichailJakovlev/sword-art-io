using UnityEngine;

public class HealItem : MonoBehaviour, IItem
{
    GameObject IItem.GameObject => this.gameObject;
    private ItemPool _itemPool;
    [SerializeField] private int _healPointValue;

    private void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
    }

   public  void OnCollisionEnter(Collision collision)
   {
       if (collision.collider.layerOverridePriority == 2)
       {
           Effect(collision.gameObject);
       }
   }

    public void Effect(GameObject entity)
    {
        _itemPool.Realize(gameObject);
        entity.GetComponentInChildren<Health>().GetHeal(_healPointValue);
    }
}
