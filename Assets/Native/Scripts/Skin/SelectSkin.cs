using UnityEngine;
using Random = UnityEngine.Random;
public class SelectSkin : MonoBehaviour
{
    public GameConfig _gameConfig;
    private SaveData saveData;
    public SpriteRenderer skinSprite;
    public Animator animator;
    private GameObject enemyRandomSkin;
    private Sprite weaponSprite;
    private SwordPool swordPool;
    private IScorable scorable;
    
    public void Awake()
    {
        scorable = GetComponentInParent<IScorable>();
        if (gameObject.tag != "PlayerSkin")
        {
            EnemySkin();
        }
        else
        {
            PlayerSkin();
        }
        scorable.weapon = weaponSprite;
    }
    
    public void PlayerSkin()
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
                        skinSprite.sprite = _gameConfig.SkinsSO.skinInfo[i].prefabSkin.GetComponent<SpriteRenderer>().sprite;
                        animator.runtimeAnimatorController = _gameConfig.SkinsSO.skinInfo[i].prefabSkin.GetComponent<Animator>().runtimeAnimatorController;
                        weaponSprite = _gameConfig.SkinsSO.skinInfo[i].weaponSprite;
                        scorable.skin = skin.name;
                    }
                }
            }
        }   
    }

    public void EnemySkin()
    {
        int randomSkin = Random.Range(0, _gameConfig.SkinsSO.skinInfo.Count);
        enemyRandomSkin = _gameConfig.SkinsSO.skinInfo[randomSkin].prefabSkin;
        skinSprite.sprite = enemyRandomSkin.GetComponent<SpriteRenderer>().sprite;
        animator.runtimeAnimatorController = enemyRandomSkin.GetComponent<Animator>().runtimeAnimatorController;
        weaponSprite = _gameConfig.SkinsSO.skinInfo[randomSkin].weaponSprite;
    }
}
