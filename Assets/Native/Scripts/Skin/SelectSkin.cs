using UnityEngine;
using Zenject;

public class SelectSkin : MonoBehaviour
{
    private GameConfig _gameConfig;
    private SaveData saveData;
    public Player _player;
    
    [Inject]
    private void Construct(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }
    
    public void LoadSkin()
    {   
        saveData = new SaveData();
        
        foreach (var skin in saveData.LoadSkins().skins)
        {
            if (skin.isSelected)
            {
                for (int i = 0; i < _gameConfig.SkinsSO.skinInfo.Count; i++)
                {
                    if (skin.name == _gameConfig.SkinsSO.skinInfo[i].name.ToString())
                    {
                        Instantiate(_gameConfig.SkinsSO.skinInfo[i].prefabSkin, transform.position, Quaternion.identity, gameObject.transform);
                    }
                }
            }
        }   
    }

    void Start()
    {
        _player._shadow.SetActive(true);
    }
}
