using UnityEngine;

public class HealItem : MonoBehaviour, IItem
{
    GameObject IItem.GameObject => this.gameObject;
    private ItemPool _itemPool;
    [SerializeField] private int _healPointValue;
    private AudioData _audioData;

    private void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
        _audioData = FindObjectOfType<AudioData>();
    }

   public  void OnCollisionEnter(Collision collision)
   {
       if (collision.collider.layerOverridePriority == 2)
       {
           if (collision.gameObject.tag == "Player")
           {
               _audioData.coinSound.pitch = Random.Range(0.9f, 1.1f);
               _audioData.coinSound.Play();
           }
           Effect(collision.gameObject);
       }
   }

    public void Effect(GameObject entity)
    {
        _itemPool.Realize(gameObject);
        entity.GetComponentInChildren<Health>().GetHeal(_healPointValue);
    }
}
