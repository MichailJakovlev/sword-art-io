using System;
using System.Collections.Generic;
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

    private Image _skinImage;
    private Image _backgroundRarity;
    private List<SkinInfo> skinInfoCopy = new List<SkinInfo>();
    
    [System.Serializable]
    public class OrderedPrefab
    {
        public int order;
        public string name;
    }


    [Inject]
    private void Construct(GameConfig gameConfig, ISaveData saveData)
    {
        _gameConfig = gameConfig;
        _saveData = saveData;
    }

    private void Awake()
    {
        InstantiateInventoryItems();
    }

    private void OnEnable()
    {
        EnableInventoryItems();
    }

    public void ShowSelectedSkin()
    {
        var _gridInventory = transform;
        var fromJson = JsonUtility.FromJson<SaveData.SkinData>(PlayerPrefs.GetString("skinData"));
        for (var i = 0; i < _gridInventory.childCount; i++)
        {
            _gridInventory.GetChild(i).GetChild(1).gameObject.SetActive(false);
            var name = _gridInventory.GetChild(i).GetComponent<SkinCardData>().skinName;
            var currentSkin = fromJson.skins.Find(skin => skin.name == name);
            if (currentSkin.isSelected == true)
            {
                transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    
    private void InstantiateInventoryItems()
    {
        var _gridInventory = transform;
        var fromJson = JsonUtility.FromJson<SaveData.SkinData>(PlayerPrefs.GetString("skinData"));

        skinInfoCopy = _gameConfig.SkinsSO.skinInfo;
        List<OrderedPrefab> skinListSorted = new List<OrderedPrefab>();
        
        for (int i = 0; i < fromJson.skins.Count; i++)
        {
            var rare = skinInfoCopy[i].skinsRarity;
            
            var skinInfoName = skinInfoCopy[i].name.ToString();
            var sortingOrder = 0;
            if (fromJson.skins.Find(skin => skin.name == skinInfoName).isUnlocked == true)
            {
                sortingOrder = _gameConfig.RaritySO.rarityInfo.Find(item => item.skinsRarity == rare).sortingOrder;
            }
            skinListSorted.Add(new OrderedPrefab { order = sortingOrder, name = skinInfoName });
        }
            
        skinListSorted.Sort((x, y) => x.order - y.order);
        skinListSorted.Reverse();
        
        for (int i = 0; i < fromJson.skins.Count; i++)
        {
            GameObject newElement = Instantiate(_gameConfig.SkinsSO.skinCardPrefab, _gridInventory);
            
            var currentSkinData = fromJson.skins.Find(skin => skin.name == skinListSorted[i].name);
            if (currentSkinData.isUnlocked == false)
            {
                newElement.GetComponent<SkinCardData>().lockedSkinImage.SetActive(true);
            }
            
            SkinInfo skin = _gameConfig.SkinsSO.skinInfo.Find(skin => skinListSorted[i].name == skin.name.ToString());
            newElement.GetComponent<SkinCardData>().skinName = skin.name.ToString();
            _backgroundRarity = newElement.transform.GetComponent<Image>();
            _skinImage = newElement.transform.GetChild(0).GetComponent<Image>();

            if (currentSkinData.isSelected == true)
            {
                newElement.transform.GetChild(1).gameObject.SetActive(true);
            }

            if (currentSkinData.isUnlocked == true)
            {
                var button = newElement.AddComponent<Button>();
                var handler = button.GetComponent<ButtonHandler>();
                handler.enabled = true;
                button.onClick.AddListener(() => _saveData.SaveData.SelectSkin(skin.name.ToString()));
                button.onClick.AddListener(() => ShowSelectedSkin());
                button.onClick.AddListener(() => handler.OnClickSound());
            }
            
            RarityInfo skinRarity =
                _gameConfig.RaritySO.rarityInfo.Find(rarity => skin.skinsRarity == rarity.skinsRarity);

            _backgroundRarity.color = skinRarity.color;
            _skinImage.sprite = skin.sprite;
        }
    }

    private void EnableInventoryItems()
    {
        var _gridInventory = transform;
        var fromJson = JsonUtility.FromJson<SaveData.SkinData>(PlayerPrefs.GetString("skinData"));
        
        skinInfoCopy = _gameConfig.SkinsSO.skinInfo;
        List<OrderedPrefab> skinListSorted = new List<OrderedPrefab>();
        
        for (int i = 0; i < fromJson.skins.Count; i++)
        {
            var rare = skinInfoCopy[i].skinsRarity;
            
            var skinInfoName = skinInfoCopy[i].name.ToString();
            var sortingOrder = 0;
            if (fromJson.skins.Find(skin => skin.name == skinInfoName).isUnlocked == true)
            {
                sortingOrder = _gameConfig.RaritySO.rarityInfo.Find(item => item.skinsRarity == rare).sortingOrder;
            }
            skinListSorted.Add(new OrderedPrefab { order = sortingOrder, name = skinInfoName });
        }
        
        skinListSorted.Sort((x, y) => x.order - y.order);
        skinListSorted.Reverse();
        
        for (int i = 0; i < fromJson.skins.Count; i++)
        {
            var currentSkinData = fromJson.skins.Find(skin => skin.name == skinListSorted[i].name);
            
            SkinInfo skin = _gameConfig.SkinsSO.skinInfo.Find(skin => currentSkinData.name == skin.name.ToString());
            _gridInventory.GetChild(i).GetComponent<SkinCardData>().skinName = skin.name.ToString();
            _backgroundRarity = _gridInventory.GetChild(i).transform.GetComponent<Image>();
            _skinImage = _gridInventory.GetChild(i).GetChild(0).GetComponent<Image>();
            
            RarityInfo skinRarity =
                _gameConfig.RaritySO.rarityInfo.Find(rarity => skin.skinsRarity == rarity.skinsRarity);

            _backgroundRarity.color = skinRarity.color;
            _skinImage.sprite = skin.sprite;

            _gridInventory.GetChild(i).GetComponent<SkinCardData>().selectorImage.SetActive(false);
            if (currentSkinData.isSelected == true)
            {
                _gridInventory.GetChild(i).GetComponent<SkinCardData>().selectorImage.SetActive(true);
            }
            
            if (currentSkinData.isUnlocked == true)
            {
                Button button;
                if (_gridInventory.GetChild(i).GetComponent<Button>() != null)
                {
                    button = _gridInventory.GetChild(i).GetComponent<Button>();
                }
                else
                {
                    button = _gridInventory.GetChild(i).AddComponent<Button>();
                }
                button.onClick.RemoveAllListeners();
                var handler = button.GetComponent<ButtonHandler>();
                handler.enabled = true;
                _gridInventory.GetChild(i).GetComponent<SkinCardData>().lockedSkinImage.SetActive(false);
                button.onClick.AddListener(() => _saveData.SaveData.SelectSkin(skin.name.ToString()));
                button.onClick.AddListener(() => ShowSelectedSkin());
                button.onClick.AddListener(() => handler.OnClickSound());
            }
        }
    }
}