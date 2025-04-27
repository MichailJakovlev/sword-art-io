using UnityEngine;

public class Player : MonoBehaviour, IPlayer, IScorable
{
    [SerializeField] private GameObject _nameUI;
    Player IPlayer.Player => this;
    private Health _health;
    public GameObject GameObject => gameObject;
    public SwordPool _swordPool;
    public GameObject _shadow;
   
    
    public int score { get; set; }
    public string name { get; set; }
    public Sprite weapon { get; set; }
    public string skin  { get; set; }

    private void Start()
    {
        name = PlayerPrefs.GetString("playerName");    
        _health = GetComponent<Health>();
        _swordPool = GetComponentInChildren<SwordPool>();
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
