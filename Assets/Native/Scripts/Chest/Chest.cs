using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
   [SerializeField] private List<CoinDroper> _coinDropers;
   [SerializeField] private GameObject _chestSprite;
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
         _health--;
         if (_health <= 0)
         {
            ChestOpen();
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
      _collider.enabled = false;
      _chestSprite.SetActive(false);
      StartCoroutine(Respawn());
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
