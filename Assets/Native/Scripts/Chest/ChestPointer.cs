    using UnityEngine;

public class ChestPointer : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private Camera _camera;
    [SerializeField] public Transform _pointerIcon;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Vector3 fromPlayerToChest = transform.position - _player.position;
        Ray ray = new Ray(_player.position, fromPlayerToChest);
        
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        
        float minDistance = Mathf.Infinity;
        int planeIndex = 0;
        
        for (int i = 0; i < 4; i++)
        {
            if (planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    planeIndex = i;
                }
            }
        }
        
        minDistance = Mathf.Clamp(minDistance,0, fromPlayerToChest.magnitude);
        
        Vector3 worldPointerPosition = ray.GetPoint(minDistance);
        _pointerIcon.position = _camera.WorldToScreenPoint(worldPointerPosition);
        _pointerIcon.rotation = GetIconRotation(planeIndex);

        if (fromPlayerToChest.magnitude > minDistance)
        {
            _pointerIcon.gameObject.SetActive(true);
        }
        else
        {
            _pointerIcon.gameObject.SetActive(false);
        }
    }

    Quaternion GetIconRotation(int planeIndex)
    {
        switch (planeIndex)
        {
            case 0:
                return Quaternion.Euler(0, 0, 90f);
            case 1:
                return Quaternion.Euler(0, 0, -90f);
            case 2:
                return Quaternion.Euler(0, 0, 180f);
            case 3:
                return Quaternion.Euler(0, 0, 0f);
            default:
                return Quaternion.identity;
        }
    }
    
    
}
