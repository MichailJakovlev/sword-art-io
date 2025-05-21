using TMPro;
using UnityEngine;

public class EntityNameUI : MonoBehaviour
{
      public Transform _entity;
      public TextMeshProUGUI _text;
      public TextMeshProUGUI _shadow;
      private void Start()
      {
            _text.text = _entity.GetComponent<IScorable>().name;
            _shadow.text = _text.text;
            gameObject.transform.position = _entity.position;
            
      }
}
