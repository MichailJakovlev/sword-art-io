using UnityEngine;
using Zenject;

public class Sword : MonoBehaviour
{
    private SwordPool _swordPull;

    private void Start()
    {
        _swordPull = GetComponentInParent<SwordPool>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.layerOverridePriority >= 2)
        {
            _swordPull.Realize(gameObject);
        }
        else if(collision.collider.layerOverridePriority == 0)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage();
        }
    }  
}
