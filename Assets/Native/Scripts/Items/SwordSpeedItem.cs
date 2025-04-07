using UnityEngine;

public class SwordSpeedItem : MonoBehaviour, IItem
{
    [SerializeField] private SwordsRotate _swordRotate;
    GameObject IItem.GameObject => this.gameObject;

    private ItemPool _itemPool;
    private float _buffSpeed;

    public void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
        _buffSpeed = _swordRotate._swordsRotateSpeed * 3;
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
        entity.GetComponentInChildren<SwordsRotate>()._swordsRotateSpeed = _buffSpeed;

        entity.GetComponent<SwordSpeedBuffTimer>().StartBuffTimer(_buffSpeed / 3);
    }
}
