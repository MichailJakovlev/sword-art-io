using UnityEngine;

public class SwordsRotate : MonoBehaviour
{
    [SerializeField] private GameObject _swordsCenter;
    [SerializeField] public float _swordsRotateSpeed;

    private void Start()
    {
        gameObject.transform.rotation = new Quaternion(90, 0, 0, 90);
    }

    private void FixedUpdate()
    {
        _swordsCenter.transform.Rotate(0, 0, _swordsRotateSpeed);
    }
}
