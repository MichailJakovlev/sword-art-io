using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundMenuScene : MonoBehaviour, IBackgroundMenuScene
{
    BackgroundMenuScene IBackgroundMenuScene.BackgroundMenuScene => this;
    
    private GameConfig _gameConfig;
    private ISaveData _saveData;
    private UISwitcher _uiSwitcher;
    
    [SerializeField] private GameObject _currentSkinParent;
    
    [Inject]
    private void Construct(GameConfig gameConfig, ISaveData saveData, UISwitcher uiSwitcher)
    {
        _gameConfig = gameConfig;
        _saveData = saveData;
        _uiSwitcher = uiSwitcher;
    }
    
    private void Start()
    {
        for (var i = 0; i < _gameConfig.SkinsSO.skinInfo.Count; i++)
        {
            var skinInstantiate = Instantiate(_gameConfig.SkinsSO.skinInfo[i].prefabSkin, _currentSkinParent.transform);
            skinInstantiate.SetActive(false);
            skinInstantiate.GetComponent<SpriteRenderer>().sortingOrder = 2;
            skinInstantiate.GetComponent<Animator>().enabled = false;
            var currentSkinData = _saveData.SaveData.LoadSkins().skins[i];
            if (_gameConfig.SkinsSO.skinInfo[i].name.ToString() == currentSkinData.name)
            {
                if (currentSkinData.isSelected == true)
                {
                    skinInstantiate.SetActive(true);
                    skinInstantiate.GetComponent<Animator>().enabled = true;
                }
            }
        }
             
    }
}