using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaseScreeen : MonoBehaviour
{
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject openCaseButton;
    [SerializeField] private GameObject skinLot;
    [SerializeField] private GameObject caseImage;
    [SerializeField] private CanvasGroup openCaseAria;
    
    [SerializeField] private GameObject sellSkinButton;
    [SerializeField] private GameObject inventoryButton;

    public TextMeshProUGUI costSellText; 
    public TextMeshProUGUI costSellTextShadow; 
    
    public Image skinLotImage;
    public Image skinLotBackground;

    private IEnumerator CoinTextAnimation()
    {
        for (int i = 0; i < 30; i++)
        {
            skinLotImage.transform.localScale  += new Vector3(0.2f, 0.2f, 0f);
            // skinLotBackground.color += new Color(0,0,0,0.01f);
            // _coinShadowText.fontSize  += 1f;
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 20; i++)
        {
            // _coinText.fontSize  -= 1f;
            // _coinShadowText.fontSize  -= 1f;
            // skinLotBackground.color -= new Color(0,0,0,0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    
    private void OnEnable()
    {
        caseImage.SetActive(true);
        returnButton.SetActive(true);
        openCaseButton.SetActive(true);
        skinLot.SetActive(false);
        skinLotImage.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void HideUI()
    {
        returnButton.SetActive(false);
        openCaseButton.SetActive(false);
    }

    public void EndAnimation()
    {
        returnButton.SetActive(true);
        openCaseAria.alpha = 0;
        skinLot.SetActive(true);
        caseImage.SetActive(false);
        StartCoroutine(CoinTextAnimation());
        
    }

    public void ButtonsShow(string lotSkinName)
    {
        if (JsonUtility.FromJson<SaveData.SkinData>(PlayerPrefs.GetString("skinData")).skins.Find(skin => skin.name == lotSkinName).isUnlocked == true)
        {
            sellSkinButton.SetActive(true);
            inventoryButton.SetActive(false);
        }
        else
        {
            sellSkinButton.SetActive(false);
            inventoryButton.SetActive(true);
        }
    }
}
