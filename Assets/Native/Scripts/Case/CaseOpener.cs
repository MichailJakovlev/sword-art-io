using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CaseOpener : MonoBehaviour, ICaseOpener
{
    private Vector2 targetPosition;
    private GameConfig _gameConfig;
    private RectTransform _grid;
    private Image _skinImage;
    private Image _backgroundRarity;
    private List<SkinNames> caseItems;
    [SerializeField] private CaseHandler _caseHandler;

    [Inject]
    public void Construct(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
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
        // string list = "";
        // int num = 0;
        for (int i = 0; i < caseItems.Count; i++)
        {
            GameObject newElement = Instantiate(_gameConfig.CaseSO.itemPrefab, _grid);

            _backgroundRarity = newElement.transform.GetComponent<Image>();
            _skinImage = newElement.transform.GetChild(0).GetComponent<Image>();

            SkinInfo skin = _gameConfig.SkinsSO.skinInfo.Find(skin => caseItems[i] == skin.name);
            RarityInfo skinRarity = _gameConfig.RaritySO.rarityInfo.Find(rarity => skin.skinsRarity == rarity.skinsRarity);

            _backgroundRarity.color = skinRarity.color;
            _skinImage.sprite = skin.sprite;
            // num++;
            // list += $"{caseItems[i]} ";
        }
        // Debug.Log($"[{num}] " + $"[{list}]");
        Debug.Log(caseItems[^4]);
        yield return null;
    }

    private IEnumerator SpinAnimation()
    {
        yield return new WaitForSeconds(1f);
        _caseHandler.SetAlpha();

        float elapsed = 0f;
        var xGridCellSize = _grid.GetComponent<GridLayoutGroup>().cellSize.x;
        var xGridSpacing = _grid.GetComponent<GridLayoutGroup>().spacing.x;
        var length = caseItems.Count;
        Vector2 velocity = Vector2.zero;

        var endPosOfItem = (length - 3) * (xGridCellSize + xGridSpacing);

        targetPosition = new(UnityEngine.Random.Range((endPosOfItem - xGridCellSize - xGridSpacing) * -1, (endPosOfItem - xGridSpacing) * -1) + _grid.rect.width / 2, 0);


        while (elapsed < _gameConfig.CaseSO.spinDuration)
        {
            elapsed += Time.deltaTime;

            _grid.anchoredPosition = Vector2.SmoothDamp(_grid.anchoredPosition, targetPosition, ref velocity, elapsed * _gameConfig.CaseSO.spinSmooth, _gameConfig.CaseSO.spinMaxSpeed, Time.deltaTime * _gameConfig.CaseSO.spinSpeed);

            if (velocity == Vector2.zero)
            {
                elapsed = _gameConfig.CaseSO.spinDuration;
            }
            yield return null;
        }
        _grid.anchoredPosition = targetPosition;
    }

    private void RollSkins()
    {
        StartCoroutine(SpinAnimation());
    }

    private void Reset()
    {
        _grid = (RectTransform)GameObject.Find("Grid").transform;
        _grid.anchoredPosition = new Vector2(0, 0);
        foreach (Transform child in _grid.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void OpenCase()
    {
        Reset();
        StartCoroutine(InstantiateCaseItems(ShuffleItems(FillArray())));
        RollSkins();
    }

}
