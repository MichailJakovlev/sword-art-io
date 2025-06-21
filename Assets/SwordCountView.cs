using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwordCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _swordCountText;
    [SerializeField] private TextMeshProUGUI _swordCountShadowText;
    [SerializeField] private RawImage _swordCountImage;
    private SwordPool _swordPool;

    void Start()
    {
        _swordCountImage = GetComponentInChildren<RawImage>();
        _swordCountImage.texture = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>().weapon.texture;
        _swordPool = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._swordPool;
    }

     public void PlusSwordCountText()
     {
         int swordCount = _swordPool._iterator - 1;
        _swordCountShadowText.text = swordCount.ToString(); 
        _swordCountText.text = _swordCountShadowText.text;
        StartCoroutine(PlusSwordCountAnimation());
     }

    public void MinusSwordCountText()
    {
        int swordCount = _swordPool._iterator - 1;
        _swordCountShadowText.text = swordCount.ToString(); 
        _swordCountText.text = _swordCountShadowText.text;
    }

    private IEnumerator PlusSwordCountAnimation()
    {
        for (int i = 0; i < 40; i++)
        {
            if (_swordCountText.fontSize < 80)
            {
                _swordCountText.fontSize += 0.5f;
                _swordCountShadowText.fontSize  += 0.5f;
            }
            
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 40; i++)
        {
            if (_swordCountText.fontSize > 61)
            {
                _swordCountText.fontSize  -= 0.5f;
                _swordCountShadowText.fontSize  -= 0.5f;
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }
}
