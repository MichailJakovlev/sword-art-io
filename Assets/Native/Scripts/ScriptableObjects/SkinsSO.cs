using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinsSO", menuName = "ScriptableObjects/SkinsSO")]
public class SkinsSO : ScriptableObject
{
    public List<SkinInfo> skinInfo;
}
