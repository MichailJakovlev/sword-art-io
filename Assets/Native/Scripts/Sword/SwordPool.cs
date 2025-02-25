using UnityEngine;
using Zenject;

public class SwordPool : MonoBehaviour, ISwordPool
{
    private ISwordPool _iSwordPool;
    SwordPool ISwordPool.SwordPool => this;

    [SerializeField] private GameObject _sword;
    [SerializeField] private int _swordCount;
    
    private Vector3 _axis;
    private  GameObject[] swordArray;
    private int _iterator = 1;

    void Awake()
    {
        swordArray = new GameObject[_swordCount];
        Create();
        Get();
    }

    public void Create()
    {
        for(int i = 0; i < _swordCount; i++)
        {
            swordArray[i] = Instantiate(_sword.gameObject, transform.position, Quaternion.identity, gameObject.transform);
            swordArray[i].gameObject.SetActive(false);
        }
    }

    private void PositionChanger(int value)
    {
        for (int i = 0; i < value; i++)
        {
            float _rotateValue = 360 / value * i;
            _axis.z = _rotateValue;

            swordArray[i].gameObject.transform.rotation = new Quaternion(0,0,0,0);
            swordArray[i].gameObject.transform.Rotate(_axis);
        }
    }

    public void Get()
    {
        if (_iterator <= _swordCount)
        {
            for(int i = 0; i < _iterator; i++)
            {
                swordArray[i].gameObject.SetActive(true);
            }
            for (int i = _iterator; i < _swordCount; i++)
            {
                swordArray[i].gameObject.SetActive(false);
            }

            PositionChanger(_iterator);
            _iterator++;
        }
    }

    public void Realize(GameObject sword) 
    {
        sword.SetActive(false);
        _iterator--;
    }
}
