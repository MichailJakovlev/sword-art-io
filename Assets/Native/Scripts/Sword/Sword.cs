using UnityEngine;

public class Sword : MonoBehaviour
{
    private SwordPool _swordPull;

    private void Awake()
    {
        _swordPull = GetComponentInParent<SwordPool>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.layerOverridePriority == 3)
        {
            _swordPull.Realize(gameObject);
        }
        else if(collision.collider.layerOverridePriority == 2)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage();
        }
    }  
}
