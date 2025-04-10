using UnityEngine;

[System.Serializable]
public class SkinInfo
{
    public SkinNames name;
    public bool isDefault;
    public bool isAchievementSkin;
    public Sprite sprite;
    public GameObject prefabSkin;
    public SkinsRarity skinsRarity;
    public Sprite weaponSprite;

}
