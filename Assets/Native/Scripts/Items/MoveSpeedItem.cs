using UnityEngine;

public class MoveSpeedItem : MonoBehaviour, IItem
{
    [SerializeField] private PlayerMovement _playerMovement;

    GameObject IItem.GameObject => this.gameObject;

    private ItemPool _itemPool;
    private float _buffSpeed;
    private AudioData _audioData;

    public void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
        _buffSpeed = _playerMovement._moveSpeed * 2f;
        _audioData = FindObjectOfType<AudioData>();
    }

    public void OnCollisionEnter(Collision collision)
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
        entity.GetComponent<MoveSpeedBuffTimer>().StartBuffTimer(_buffSpeed / 2);
    }
}
