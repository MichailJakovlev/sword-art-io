using UnityEngine;

public class MobileUI : MonoBehaviour
{
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
