﻿using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float animationTime = 0f;
    [SerializeField] private float amplitude = 0.1f;
    [SerializeField] private float frequency = 2f;
    [SerializeField] private float offset = 0f;
    [SerializeField] private GameObject shadow;
    [SerializeField] private float shadowScaleValue = 5;
    private Vector3 startPosition;  
    
    public void Start()
    {
        startPosition = transform.parent.position;
    }

    void Update()
    {
        animationTime += Time.deltaTime;
        offset = Mathf.Sin(animationTime * frequency) * amplitude;
        
        transform.position = transform.parent.position + new Vector3(0, offset, offset);
        
        shadow.transform.localScale = new Vector3(offset + shadowScaleValue, offset + shadowScaleValue, offset + shadowScaleValue);
    }
    
}
