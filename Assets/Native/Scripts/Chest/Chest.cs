using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Chest : MonoBehaviour
{
   [SerializeField] private List<CoinDroper> _coinDropers;
   [SerializeField] private GameObject _chestSprite;
   [SerializeField] private Animator _animator;
   [SerializeField] private GameObject _chestPointer;
   private Collider _collider;
   private int _health = 10;
   private bool _isPlayer = false;
   
   private AudioData _audioData;
   
    
   [Inject]
   private void Construct(AudioData audioData)
   {
      _audioData = audioData;
   }

   void Start()
   {
      gameObject.transform.position = new Vector3(UnityEngine.Random.Range(GameData.X * -1 + 15, GameData.X - 15), 0, UnityEngine.Random.Range(GameData.Z * -1 + 15, GameData.Z - 15));
      foreach (CoinDroper coinDroper in _coinDropers)
      {
         coinDroper.gameObject.SetActive(false);
      }
      _collider = GetComponent<Collider>();
      
   }

   public void PlayAudio()
   {
      _isPlayer = true;
      if (_health >= 1)
      {
         _audioData.hitSound.pitch = Random.Range(0.9f, 1.1f);
         _audioData?.hitSound.Play();
      }
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.collider.layerOverridePriority == 3)
      {
         StartCoroutine(ChestHitAnimation());
         _health--;
         if (_health <= 0)
         {
            _chestPointer.SetActive(false);
            if (_isPlayer)
            {
               _audioData.openChestSound.Play();
               _isPlayer = false;
            }
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
      _chestPointer.SetActive(true);
   }
}
