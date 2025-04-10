using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Inventory : MonoBehaviour, IInventory
{
    Inventory IInventory.Inventory => this;

    private GameConfig _gameConfig;
    private ISaveData _saveData;

    // private RectTransform _gridInventory;
    private Image _skinImage;
    private Image _backgroundRarity;


    [Inject]
    private void Construct(GameConfig gameConfig, ISaveData saveData)
    {
        _gameConfig = gameConfig;
        _saveData = saveData;
    }

    private void OnEnable()
    {
        InstantiateInventoryItems();
    }

    private void InstantiateInventoryItems()
    {
        var _gridInventory = transform;
        for (var i = 0; i < _gridInventory.childCount; i++)
        {
            Destroy(_gridInventory.GetChild(i).gameObject);
        }

        var fullPath = Path.Combine(Application.dataPath, _saveData.SaveData.jsonPath);
        var json = File.ReadAllText(fullPath);
        var fromJson = JsonUtility.FromJson<SaveData.SkinData>(json);

        for (int i = 0; i < fromJson.skins.Count; i++)
        {
            if (fromJson.skins[i].isUnlocked == true)
            {
                GameObject newElement = Instantiate(_gameConfig.SkinsSO.skinCardPrefab, _gridInventory);

                _backgroundRarity = newElement.transform.GetComponent<Image>();
                _skinImage = newElement.transform.GetChild(0).GetComponent<Image>();

                SkinInfo skin = _gameConfig.SkinsSO.skinInfo.Find(skin => fromJson.skins[i].name == skin.name.ToString());
                RarityInfo skinRarity =
                    _gameConfig.RaritySO.rarityInfo.Find(rarity => skin.skinsRarity == rarity.skinsRarity);

                _backgroundRarity.color = skinRarity.color;
                _skinImage.sprite = skin.sprite;
            }
        }
    }
}