using Unity.VisualScripting;
using UnityEngine;

public class ItemPool : MonoBehaviour, IItemPool
{
    private IItemPool _iItemPool;
    ItemPool IItemPool.ItemPool => this;

    [SerializeField] private Item _item;
    [SerializeField] private HealItem _healItem;
    [SerializeField] private int _itemCount;
    [SerializeField] private int _healItemCount;
    [SerializeField] private int _spawnAreaSizeX;
    [SerializeField] private int _spawnAreaSizeY;

    private Item[] itemArray;
    private HealItem[] healItemArray;


    public void Start()
    {
        itemArray = new Item[_itemCount];
        healItemArray = new HealItem[_healItemCount];
        Create();
    }

    public void Create()
    {
        for(int i = 0; i < _itemCount; i++)
        {
            itemArray[i] = Instantiate(_item, PositionChanger(), Quaternion.identity, gameObject.transform);
        }

        for (int i = 0; i < _healItemCount; i++)
        {
            healItemArray[i] = Instantiate(_healItem, PositionChanger(), Quaternion.identity, gameObject.transform);
        }
    }

    public Vector2 PositionChanger()
    {
        Vector2 itemPosition;

        itemPosition.x = Random.Range(_spawnAreaSizeX * -1, _spawnAreaSizeX);
        itemPosition.y = Random.Range(_spawnAreaSizeX * -1, _spawnAreaSizeY);

        return itemPosition;
    }

    public void Realize(GameObject item)
    {
        item.transform.position = PositionChanger();
    }
}
