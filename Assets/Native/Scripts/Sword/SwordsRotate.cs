using UnityEngine;

public class SwordsRotate : MonoBehaviour
{
    [SerializeField] private GameObject _swordsCenter;
    [SerializeField] private float _swordsRotateSpeed;

    private void Start()
    {
        gameObject.transform.rotation = new Quaternion(90, 0, 0, 90);
    }

    private void Update()
    {
        _swordsCenter.transform.Rotate(0, 0, _swordsRotateSpeed);
    }
}
