using UnityEngine;
using System.Collections;

public class SwordsRotate : MonoBehaviour
{
    [SerializeField] private GameObject _swordsCenter;
    [SerializeField] private float _swordsRotateSpeed;

    private void Update()
    {
        _swordsCenter.transform.Rotate(0, 0, _swordsRotateSpeed);
    }
}
