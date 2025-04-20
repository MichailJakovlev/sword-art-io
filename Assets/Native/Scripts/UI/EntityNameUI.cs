using TMPro;
using UnityEngine;

public class EntityNameUI : MonoBehaviour
{
      public Transform _entity;
      public TextMeshProUGUI _text;
      private void Start()
      {
            _text.text = _entity.GetComponent<IScorable>().name;
            gameObject.transform.position = _entity.position;
            
      }
}
