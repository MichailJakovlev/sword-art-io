using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class FullscreenAd: MonoBehaviour, IFullscreenAd
{
    [DllImport("__Internal")]
    public static extern void ShowFullscreen();

    private IFullscreenAd _fullscreenAd;
    FullscreenAd IFullscreenAd.FullscreenAd => this;

    private void Start()
    {
       // ShowFullscreenAd();
    }

    public void ShowFullscreenAd()
    {
        ShowFullscreen();
    }
}
