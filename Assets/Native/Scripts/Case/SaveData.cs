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
        var defaultSkin = _gameConfig.SkinsSO.skinInfo.Find(skin => skin.isDefault).name.ToString();
        AddSkin(defaultSkin, true, true);
        foreach(SkinInfo skin in _gameConfig.SkinsSO.skinInfo)
        {
            AddSkin(skin.name.ToString(), false, false);
        }
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

    private SkinData LoadSkins()
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