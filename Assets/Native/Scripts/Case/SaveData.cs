using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

public class SaveData : MonoBehaviour, ISaveData
{
    SaveData ISaveData.SaveData => this;
    private GameConfig _gameConfig;
    [HideInInspector] public string jsonPath = "skins.json";

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

    private void Awake()
    {
        if (!File.Exists(Path.Combine(Application.dataPath, jsonPath)))
        {
            SaveSkins(new SkinData());
        }
        var defaultSkin = _gameConfig.SkinsSO.skinInfo.Find(skin => skin.isDefault).name.ToString();
        AddSkin(defaultSkin, true, true);
        foreach(SkinInfo skin in _gameConfig.SkinsSO.skinInfo)
        {
            AddSkin(skin.name.ToString(), false, false);
        }
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
        var fullPath = Path.Combine(Application.dataPath, jsonPath);
        var json = File.ReadAllText(fullPath);
        var fromJson = JsonUtility.FromJson<SkinData>(json);
        foreach (var skin in skinData.skins)
        {
            skin.isSelected = false;
        }
        var selected = skinData.skins.Find(skin => skin.name == skinName);
        selected.isSelected = true;
        SaveSkins(skinData);  
    }

    public void AddSkin(string name, bool isUnlocked, bool isSelected)
    {
        SkinData skinData = LoadSkins();

        Skin newSkin = new Skin
        {
            name = name,
            isUnlocked = isUnlocked,
            isSelected = isSelected
        };

        var fullPath = Path.Combine(Application.dataPath, jsonPath);
        var json = File.ReadAllText(fullPath);
        var fromJson = JsonUtility.FromJson<SkinData>(json);
        var isRepeat = fromJson.skins.Exists(skin => skin.name == name);

        if (!isRepeat)
        {
            skinData.skins.Add(newSkin);
        }

        SaveSkins(skinData);
    }

    private void SaveSkins(SkinData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        File.WriteAllText(Path.Combine(Application.dataPath, jsonPath), json);
    }

    public SkinData LoadSkins()
    {
        string fullPath = Path.Combine(Application.dataPath, jsonPath);

        if (File.Exists(fullPath))
        {
            var json = File.ReadAllText(fullPath);
            return JsonUtility.FromJson<SkinData>(json);
        }
        else
        {
            return new SkinData();
        }
    }
}