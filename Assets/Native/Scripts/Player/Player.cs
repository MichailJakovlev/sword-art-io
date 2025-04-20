using UnityEngine;

public class Player : MonoBehaviour, IPlayer, IScorable
{
    private Player _player;
    Player IPlayer.Player => this;
    public GameObject GameObject => gameObject;
    private Health _health;
    public SwordPool _swordPool;
    public GameObject _shadow;
    [SerializeField] private GameObject _nameUI;
    private SelectSkin _selectSkin;
    public int score { get; set; }
    public string name { get; set; }

    private void Awake()
    {
        name = "Гитлер";    
        _health = GetComponent<Health>();
        _swordPool = GetComponentInChildren<SwordPool>();
        _selectSkin = GetComponentInChildren<SelectSkin>();
    }

    void Start()
    {
        _selectSkin.LoadSkin();
    }
    
    public void Death()
    {
        _nameUI.SetActive(false);
        _shadow.SetActive(false);
        _swordPool.RealizeAll();
        Respawn();
    }

    public void Respawn()
    {
        _nameUI.SetActive(true);
        _shadow.SetActive(true);
        _health._healthValue = _health._maxHealthValue;
        transform.position = new Vector3(UnityEngine.Random.Range(GameData.X * -1 + 15, GameData.X - 15), 0, UnityEngine.Random.Range(GameData.Z * -1 + 15, GameData.Z - 15));
        _swordPool.Get();
    }
}
