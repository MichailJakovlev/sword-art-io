using UnityEngine;

public class SwordSkin : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private IScorable _scorable;

    public void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _scorable = GetComponentInParent<IScorable>();
        _spriteRenderer.sprite = _scorable.weapon;
    }
}
