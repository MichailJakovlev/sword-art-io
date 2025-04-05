using UnityEngine;

public class ItemPool : MonoBehaviour, IItemPool
{
    ItemPool IItemPool.ItemPool => this;

    [SerializeField] private SwordAddItem _swordAddItem;
    [SerializeField] private HealItem _healItem;
    [SerializeField] private MoveSpeedItem _moveSpeedItem;
    [SerializeField] private SwordSpeedItem _swordSpeedItem;
    
    private IItem _item;

    public static IItem[] items;

    public void Start()
    {
        items = new IItem[GameData.HealItemCount + GameData.SwordAddItemCount + GameData.SwordSpeedItemCount + GameData.MoveSpeedItemCount];
        Create();
    }

    public void Create()
    {
        for(int i = 0; i < GameData.SwordAddItemCount; i++)
        {
            items[i] = Instantiate(_swordAddItem, PositionChanger(), new Quaternion(45, 0, 0, 90), gameObject.transform);
        }

        for (int i = GameData.SwordAddItemCount; i < GameData.HealItemCount + GameData.SwordAddItemCount; i++)
        {
            items[i] = Instantiate(_healItem, PositionChanger(), new Quaternion(45, 0, 0, 90), gameObject.transform);
        }

        for (int i = GameData.HealItemCount + GameData.SwordAddItemCount; i < GameData.MoveSpeedItemCount + GameData.HealItemCount + GameData.SwordAddItemCount; i++)
        {
            items[i] = Instantiate(_moveSpeedItem, PositionChanger(), new Quaternion(45, 0, 0, 90), gameObject.transform);
        }

        for (int i = GameData.MoveSpeedItemCount + GameData.HealItemCount + GameData.SwordAddItemCount; i < GameData.SwordSpeedItemCount + GameData.MoveSpeedItemCount + GameData.HealItemCount + GameData.SwordAddItemCount; i++)
        {
            items[i] = Instantiate(_swordSpeedItem, PositionChanger(), new Quaternion(45, 0, 0, 90), gameObject.transform);
        }
    }

    public Vector3 PositionChanger()
    {
        Vector3 itemPosition;

        itemPosition.x = Random.Range(GameData.X * -1, GameData.X);
        itemPosition.y = 0.5f;
        itemPosition.z = Random.Range(GameData.Z * -1, GameData.Z);

        return itemPosition;
    }

    public void Realize(GameObject item)
    {
        item.transform.position = PositionChanger();
    }
}
    