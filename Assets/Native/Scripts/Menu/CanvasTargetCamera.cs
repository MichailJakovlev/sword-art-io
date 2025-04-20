using System;
using UnityEngine;

public class CanvasTargetCamera : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        _canvas.worldCamera = Camera.main;
    }
}
