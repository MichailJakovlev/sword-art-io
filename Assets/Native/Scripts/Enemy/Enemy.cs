using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IScorable
{
    private EnemyPool _enemyPool;
    private SpriteRenderer _spriteRenderer;
    public GameObject _shadow;
    public TextMeshProUGUI _shadowText;
    public GameObject _nameUI;
    private Animations _animations;
    private Health _health;
    [SerializeField] private CoinDroper _coinDroper;
    public int score { get; set; }
    public string name { get; set; }
    public Sprite weapon { get; set; }
    public string skin  { get; set; }
    
    private void Start()
    {
        _coinDroper.gameObject.SetActive(false);
        _health = GetComponent<Health>();
        _enemyPool = GetComponentInParent<EnemyPool>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Realize()
    {
        _coinDroper.gameObject.SetActive(true);
        _coinDroper.Drop();
        _nameUI.SetActive(false);
        _shadow.SetActive(false);
        _shadowText.gameObject.SetActive(false);
        
        _spriteRenderer.enabled = false;
        _health._healthSlider.gameObject.SetActive(false);
        StartCoroutine(Timer());
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        _enemyPool.Get(gameObject);
    }
}
