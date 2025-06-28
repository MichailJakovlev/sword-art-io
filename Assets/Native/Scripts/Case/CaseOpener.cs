using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CaseOpener : MonoBehaviour, ICaseOpener
{
    CaseOpener ICaseOpener.CaseOpener => this;
    private GameConfig _gameConfig;
    private ISaveData _saveData;

    private Vector2 targetPosition;
    private RectTransform _grid;
    private Image _skinImage;
    private Image _backgroundRarity;
    private List<SkinNames> caseItems;
    
    [SerializeField] private CaseHandler _caseHandler;
    
    private GameObject _caseHandlerGo;

    private string currentSkinLotName;
    

    private int skinLot = 7;

    private bool firstEnabledFlag = false;

    [Inject]
    private void Construct(GameConfig gameConfig, ISaveData saveData)
    {
        _gameConfig = gameConfig;
        _saveData = saveData;
    }

    private void Start()
    {
        _caseHandlerGo = GameObject.Find("TestMenuCanvas(Clone)");
    }

    private List<SkinNames> FillArray()
    {
        caseItems = new List<SkinNames>();
        List<SkinInfo> skinInfo = _gameConfig.SkinsSO.skinInfo;
        for (int i = 0; i < _gameConfig.CaseSO.amount; i++)
        {
            if (!skinInfo[i % skinInfo.Count].isAchievementSkin && !skinInfo[i % skinInfo.Count].isDefault)
            {
                caseItems.Add(skinInfo[i % skinInfo.Count].name);
            }
        }
        return caseItems;
    }

    private List<SkinNames> ShuffleItems<SkinNames>(List<SkinNames> caseItems)
    {
        List<SkinNames> copy = caseItems.ToList();
        var rng = new System.Random();
        int n = copy.Count;
        while (n > 1)
        {
            int k = rng.Next(n--);
            SkinNames temp = copy[n];
            copy[n] = copy[k];
            copy[k] = temp;
        }
        return copy;
    }

    private IEnumerator InstantiateCaseItems(List<SkinNames> caseItems)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < caseItems.Count; i++)
        {
            GameObject newElement;
            if (firstEnabledFlag == false)
            {
                newElement = Instantiate(_gameConfig.SkinsSO.skinCardPrefab, _grid);
            }
            else
            {
                newElement = _grid.GetChild(i).gameObject;
                newElement.SetActive(true);
            }

            _backgroundRarity = newElement.transform.GetComponent<Image>();
            _skinImage = newElement.transform.GetChild(0).GetComponent<Image>();

            SkinInfo skin = _gameConfig.SkinsSO.skinInfo.Find(skin => caseItems[i] == skin.name);
            RarityInfo skinRarity =
                _gameConfig.RaritySO.rarityInfo.Find(rarity => skin.skinsRarity == rarity.skinsRarity);

            _backgroundRarity.color = skinRarity.color;
            _skinImage.sprite = skin.sprite;
        }

        Debug.Log(caseItems[^skinLot]);
        string caseItem = caseItems[^skinLot].ToString();
        _caseHandlerGo.GetComponent<CaseHandler>()._caseScreeen.ButtonsShow(caseItem);
        _saveData.SaveData.UnlockSkin(caseItem);
        currentSkinLotName = caseItem;
        
        if (firstEnabledFlag == false)
        {
            firstEnabledFlag = true;
        }
        yield return null;
    }

    private IEnumerator SpinAnimation()
    {
        yield return new WaitForSeconds(1f);
        _caseHandler.SetAlpha(1);

        int itemPadding = 5;
        float elapsed = 0f;
        var xGridCellSize = _grid.GetComponent<GridLayoutGroup>().cellSize.x;
        var xGridSpacing = _grid.GetComponent<GridLayoutGroup>().spacing.x;
        var length = caseItems.Count;
        Vector2 velocity = Vector2.zero;

        var endPosOfItem = (length - (skinLot - 1)) * (xGridCellSize + xGridSpacing);

        Debug.Log(endPosOfItem);
        
        // if (endPosOfItem)
        // {
        //     
        // }

        var minPos = (endPosOfItem - xGridCellSize - xGridSpacing + itemPadding) * -1;
        var maxPos = (endPosOfItem - xGridSpacing - itemPadding) * -1;

        // Debug.Log(minPos + " : " + maxPos);

        targetPosition = new(UnityEngine.Random.Range(minPos, maxPos) + _grid.rect.width / 2, 0);

        // Debug.Log(targetPosition.x);

        while (elapsed < _gameConfig.CaseSO.spinDuration)
        {
            elapsed += Time.deltaTime;
    
            _grid.anchoredPosition = Vector2.SmoothDamp(_grid.anchoredPosition, targetPosition, ref velocity,
                elapsed * _gameConfig.CaseSO.spinSmooth, _gameConfig.CaseSO.spinMaxSpeed,
                Time.deltaTime * _gameConfig.CaseSO.spinSpeed);
            Debug.Log(_grid.anchoredPosition);

            if (velocity == Vector2.zero)
            {
                elapsed = _gameConfig.CaseSO.spinDuration;
            }

            yield return null;
        }

        _grid.anchoredPosition = targetPosition;

        var skinLotCurrent = _gameConfig.SkinsSO.skinInfo.Find(skin => currentSkinLotName == skin.name.ToString());
        
        _caseHandlerGo.GetComponent<CaseHandler>()._caseScreeen.skinLotImage.sprite = skinLotCurrent.sprite;

        var skinLotBackground = _caseHandlerGo.GetComponent<CaseHandler>()._caseScreeen.skinLotBackground;
        var rarityInfo = _gameConfig.RaritySO.rarityInfo.Find(rarity => rarity.skinsRarity == skinLotCurrent.skinsRarity);
        _caseHandlerGo.GetComponent<CaseHandler>()._caseScreeen.costSellText.text = rarityInfo.cost.ToString();
        _caseHandlerGo.GetComponent<CaseHandler>()._caseScreeen.costSellTextShadow.text = rarityInfo.cost.ToString();
        var skinLotBackgroundAlpha = 0.4f;
        skinLotBackground.color = new Color(rarityInfo.color.r, rarityInfo.color.g, rarityInfo.color.b, skinLotBackground.color.a);

        
        
        _caseHandlerGo.GetComponent<CaseHandler>()._caseOpenAnimation.caseOpenAnimator.Play("Empty State");
        
        yield return new WaitForSeconds(0.01f);
        _caseHandlerGo.GetComponent<CaseHandler>()._caseScreeen.EndAnimation();

        
        Debug.Log("animation stoped");
    }

    private void Reset()
    {
        _grid = (RectTransform)GameObject.Find("CaseGrid").transform;
        _grid.anchoredPosition = new Vector2(0, 0);
    }
    
    public void OpenCase()
    {
        Reset();
        StartCoroutine(InstantiateCaseItems(ShuffleItems(FillArray())));
        StartCoroutine(SpinAnimation());
        foreach (Transform child in _grid.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}