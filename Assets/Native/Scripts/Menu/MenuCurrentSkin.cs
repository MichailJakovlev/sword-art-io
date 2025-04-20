using System;
using UnityEngine;
using Zenject;

public class MenuCurrentSkin : MonoBehaviour
{
    private GameConfig _gameConfig;
    private ISaveData _saveData;
    
    [SerializeField] private GameObject _currentSkinParent;
    [SerializeField] private SwordPool _swordPool;
    
    public Player scorable;
    
    [Inject]
    private void Construct(GameConfig gameConfig, ISaveData saveData)
    {
        _gameConfig = gameConfig;
        _saveData = saveData;
    }
    
    private void Awake()
    {
        var selectedSkinData = _saveData.SaveData.LoadSkins().skins.Find(skin => skin.isSelected == true);
        
        for (int i = 0; i < _gameConfig.SkinsSO.skinInfo.Count; i++)
        {
            var skinInfo = _gameConfig.SkinsSO.skinInfo[i];
            var skinInstantiate = Instantiate(skinInfo.prefabSkin, _currentSkinParent.transform);
            skinInstantiate.SetActive(false);
            skinInstantiate.GetComponent<SpriteRenderer>().sortingOrder = 6;
            skinInstantiate.GetComponent<Animator>().enabled = false;
            if (skinInfo.name.ToString() == selectedSkinData.name)
            {
                skinInstantiate.SetActive(true);
                skinInstantiate.GetComponent<Animator>().enabled = true;
                scorable.weapon = skinInfo.weaponSprite;
            }
        }
    }
    
    public void ChangeWeaponSprites()
    {
        var selectedSkinData = _saveData.SaveData.LoadSkins().skins.Find(skin => skin.isSelected == true);
        var weaponSelectedSprite = _gameConfig.SkinsSO.skinInfo.Find(skin => skin.name.ToString() == selectedSkinData.name).weaponSprite;
        for (int i = 0; i < _swordPool.transform.childCount; i++)
        {
            _swordPool.transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = weaponSelectedSprite;
        }
    }

    private void OnEnable()
    {
        var selectedSkinData = _saveData.SaveData.LoadSkins().skins.Find(skin => skin.isSelected == true);
        ChangeWeaponSprites();
        for (int i = 0; i < _gameConfig.SkinsSO.skinInfo.Count; i++)
        {
            var child = _currentSkinParent.transform.GetChild(i).gameObject;
            child.SetActive(false);
            child.GetComponent<Animator>().enabled = false;
            if (_gameConfig.SkinsSO.skinInfo[i].name.ToString() == selectedSkinData.name)
            {
                child.SetActive(true);
                child.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
