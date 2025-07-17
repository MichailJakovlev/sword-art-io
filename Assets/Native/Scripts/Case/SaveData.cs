using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

public class SaveData : MonoBehaviour, ISaveData
{
    [DllImport("__Internal")]
    public static extern string GetLang();
    SaveData ISaveData.SaveData => this;
    private GameConfig _gameConfig;
    
    [Inject]
    private void Construct(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    [System.Serializable]
    public class Skin
    {
        public string name;
        public bool isUnlocked;
        public bool isSelected;
    }

    [System.Serializable]
    public class SkinData
    {
        public List<Skin> skins = new List<Skin>();
    }

    private void Start()
    {
        PlayerPrefs.SetString("currentLanguage", GetLang());
    }
    
    private void LoadSkinsData()
    {
        SkinData skinData;
        if (PlayerPrefs.HasKey("skinData"))
        {
            skinData = JsonUtility.FromJson<SkinData>(PlayerPrefs.GetString("skinData"));
        }
        else
        {
            skinData = new SkinData();
            var defaultSkin = _gameConfig.SkinsSO.skinInfo.Find(skin => skin.isDefault).name.ToString();
            AddSkin(skinData, defaultSkin, true, true);
            foreach(SkinInfo skin in _gameConfig.SkinsSO.skinInfo)
            {
                AddSkin(skinData, skin.name.ToString(), false, false);
            }
        }
        
        string json = JsonUtility.ToJson(skinData, prettyPrint: true);
        PlayerPrefs.SetString("skinData", json);
    }

    public void UnlockSkin(string skinName)
    {
        SkinData skinData = LoadSkins();
        var unlocked = skinData.skins.Find(skin => skin.name == skinName);
        unlocked.isUnlocked = true;
        SaveSkins(skinData);
    }
    
    public void SelectSkin(string skinName)
    {
        SkinData skinData = LoadSkins();
        foreach (var skin in skinData.skins)
        {
            skin.isSelected = false;
        }
        var selected = skinData.skins.Find(skin => skin.name == skinName);
        selected.isSelected = true;
        SaveSkins(skinData);
    }

    public void AddSkin(SkinData skinData, string name, bool isUnlocked, bool isSelected)
    {
        Skin newSkin = new Skin
        {
            name = name,
            isUnlocked = isUnlocked,
            isSelected = isSelected
        };

        if (!skinData.skins.Exists(skin => skin.name == name))
        {
            skinData.skins.Add(newSkin);
        }

        SaveSkins(skinData);
    }

    private void SaveSkins(SkinData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        PlayerPrefs.SetString("skinData", json);
    }

    public SkinData LoadSkins()
    {
        LoadSkinsData();
        if (PlayerPrefs.HasKey("skinData"))
        {
            return JsonUtility.FromJson<SkinData>(PlayerPrefs.GetString("skinData"));
        }
        else
        {
            return new SkinData();
        }
    }
}
