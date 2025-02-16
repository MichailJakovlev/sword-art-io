using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private SkinsSO _skinSO;
    [SerializeField] private CaseSO _caseSO;
    [SerializeField] private RaritySO _raritySO;

    public SkinsSO SkinsSO { get => _skinSO; }
    public CaseSO CaseSO { get => _caseSO; }
    public RaritySO RaritySO { get => _raritySO; }

}
