using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
   [SerializeField] private List<CoinDroper> _coinDropers;
   [SerializeField] private GameObject _chestSprite;
   [SerializeField] private Animator _animator;
   private Collider _collider;
   private int _health = 10;
   

   void Start()
   {
      gameObject.transform.position = new Vector3(UnityEngine.Random.Range(GameData.X * -1 + 15, GameData.X - 15), 0, UnityEngine.Random.Range(GameData.Z * -1 + 15, GameData.Z - 15));
      foreach (CoinDroper coinDroper in _coinDropers)
      {
         coinDroper.gameObject.SetActive(false);
      }
      _collider = GetComponent<Collider>();

   }
   
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.collider.layerOverridePriority == 3)
      {
         StartCoroutine(ChestHitAnimation());
         _health--;
         if (_health <= 0)
         {
            _collider.enabled = false;
            StopAllCoroutines();
            StartCoroutine(ChestOpenAnimation());
         }
      }
   }

   private void ChestOpen()
   {
      foreach (CoinDroper coinDroper in _coinDropers)
      {
         coinDroper.gameObject.SetActive(true);
         coinDroper.Drop();
      }
      _chestSprite.SetActive(false);
      StartCoroutine(Respawn());
   }

   private IEnumerator ChestHitAnimation()
   {
      _animator.Play("Hit");
      yield return new WaitForSeconds(0.2f);
      _animator.Play("Idle");
   }
   
   private IEnumerator ChestOpenAnimation()
   {
      _animator.Play("Open");
      yield return new WaitForSeconds(0.6f);
      ChestOpen();
   }

   private IEnumerator Respawn()
   {
      yield return new WaitForSeconds(10f);
      gameObject.transform.position = new Vector3(UnityEngine.Random.Range(GameData.X * -1 + 15, GameData.X - 15), 0, UnityEngine.Random.Range(GameData.Z * -1 + 15, GameData.Z - 15));
      _health = 10;
      _chestSprite.SetActive(true);
      _collider.enabled = true;
   }
}
