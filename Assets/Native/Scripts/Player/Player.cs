using UnityEngine;

public class Player : MonoBehaviour, IPlayer, IScorable
{
    [SerializeField] private GameObject _nameUI;
    Player IPlayer.Player => this;
    private Health _health;
    public GameObject GameObject => gameObject;
    public SwordPool _swordPool;
    public GameObject _shadow;
    private PlayerMovement _playerMovement;
    private GameOverMenu _gameOverMenu;
    private Collider _collider;
    private SpriteRenderer _spriteRenderer;
    private CoinCounter _coinCounter;
   
    
    public int score { get; set; }
    public string name { get; set; }
    public Sprite weapon { get; set; }
    public string skin  { get; set; }

    private void Start()
    {
        name = PlayerPrefs.GetString("playerName");    
        _collider = GetComponent<Collider>();
        _health = GetComponent<Health>();
        _swordPool = GetComponentInChildren<SwordPool>();
        _playerMovement = GetComponent<PlayerMovement>();
        _gameOverMenu = FindFirstObjectByType<GameOverMenu>();
        _gameOverMenu?.gameObject.SetActive(false);
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _coinCounter = FindObjectOfType<CoinCounter>();
    }
    
    public void Death()
    {
        _nameUI.SetActive(false);
        _shadow.SetActive(false);
        _swordPool.RealizeAll();
        _spriteRenderer.gameObject.SetActive(false);
        _gameOverMenu.gameObject.SetActive(true);
    }

    public void Respawn()
    {
        _coinCounter.ClearCoins();
        _gameOverMenu.gameObject.SetActive(false);
        _nameUI.SetActive(true);
        _shadow.SetActive(true);
        _spriteRenderer.gameObject.SetActive(true);
        _health._healthValue = _health._maxHealthValue;
        _health._healthSlider.value = _health._maxHealthValue;
        _playerMovement.enabled = true;
        transform.position = new Vector3(UnityEngine.Random.Range(GameData.X * -1 + 15, GameData.X - 15), 0, UnityEngine.Random.Range(GameData.Z * -1 + 15, GameData.Z - 15));
        _swordPool.Get();
        _collider.enabled = true;
    }
}
