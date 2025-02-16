using System.Runtime.InteropServices;
using UnityEngine;

public class Authorization : MonoBehaviour, IAuthorization
{
    [DllImport("__Internal")]
    public static extern void AuthingPlayer();

    [DllImport("__Internal")]
    public static extern void GetPlayerAuthData();

    private IAuthorization _authorization;
    Authorization IAuthorization.Authorization => this;
    public GameObject GameObject => gameObject;

    public void Start()
    {
      //  GetPlayerAuthData();
    }

    public void Auth() => AuthingPlayer();
}
