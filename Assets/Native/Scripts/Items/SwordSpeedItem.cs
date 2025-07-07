using UnityEngine;

public class SwordSpeedItem : MonoBehaviour, IItem
{
    [SerializeField] private SwordsRotate _swordRotate;
    GameObject IItem.GameObject => this.gameObject;

    private ItemPool _itemPool;
    private float _buffSpeed;
    private AudioData _audioData;

    public void Awake()
    {
        _itemPool = GetComponentInParent<ItemPool>();
        _buffSpeed = _swordRotate._swordsRotateSpeed * 3;
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
        entity.GetComponentInChildren<SwordsRotate>()._swordsRotateSpeed = _buffSpeed;

        entity.GetComponent<SwordSpeedBuffTimer>().StartBuffTimer(_buffSpeed / 3);
    }
}
