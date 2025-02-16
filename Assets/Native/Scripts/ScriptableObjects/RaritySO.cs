using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RaritySO", menuName = "ScriptableObjects/RaritySO")]
public class RaritySO : ScriptableObject
{
    public List<RarityInfo> rarityInfo;
}
