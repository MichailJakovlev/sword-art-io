using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CaseSO", menuName = "ScriptableObjects/CaseSO")]
public class CaseSO : ScriptableObject
{
    public int amount = 30;
    public float spinSpeed = 1f;
    public float spinMaxSpeed = 3000f;
    public float spinSmooth = 0.5f;
    public float spinDuration = 10f;
    public GameObject itemPrefab;
}
