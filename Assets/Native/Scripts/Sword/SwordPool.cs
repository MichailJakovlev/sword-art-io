using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SwordPool : MonoBehaviour, ISwordPool
{
    SwordPool ISwordPool.SwordPool => this;

    [SerializeField] private GameObject _sword;
    [SerializeField] private int _swordCount;
    [SerializeField] private GameObject _swordEffect;
    [SerializeField] private GameObject[] _swordEffects;
    
    private Vector3 _axis;
    public GameObject[] swordArray;
    public int _iterator = 1;
    private SwordCountView _swordCountView;

    void Awake()
    {
        swordArray = new GameObject[_swordCount];
        
        _swordEffects = new GameObject[_swordCount];
        Create();
        Get();
        
        if (transform.parent.tag != "Player")
        {
            for (int i = 0; i < Random.Range(0,9); i++)
            {
                Get();
            }
        }
        else
        {
            _swordCountView = FindFirstObjectByType<SwordCountView>();
        }
    }

    public void Create()
    {
        for(int i = 0; i < _swordCount; i++)
        {
            _swordEffects[i] = Instantiate(_swordEffect, transform.position, gameObject.transform.rotation, gameObject.transform);
            swordArray[i] = Instantiate(_sword.gameObject, transform.position, Quaternion.identity, _swordEffects[i].transform);
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
            if (_swordCountView != null)
            {
                _swordCountView.PlusSwordCountText();
            }
        }
    }
    
    public void Realize(GameObject sword) 
    {
        sword.SetActive(false);
        _iterator--;
        if (_swordCountView != null)
        {
            _swordCountView.MinusSwordCountText();
        }
    }

    public void RealizeAll()
    {
        for (int i = 0; i < _swordCount; i++)
        {
            swordArray[i].gameObject.SetActive(false);
        }

        _iterator = 1;
    }
}
