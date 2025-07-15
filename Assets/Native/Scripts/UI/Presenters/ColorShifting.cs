using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ColorShifting: MonoBehaviour
{
    [SerializeField] private Image _highlighter;
    private GameConfig _gameConfig;
    private List<RarityInfo> rarityColors;
    
    public float transitionDuration = 2f;
    public float delayAfterTransition = 7f;
    
    private int currentIndex = 0;
    
    [Inject]
    private void Construct(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    private void Awake()
    {
        rarityColors = _gameConfig.RaritySO.rarityInfo;
    }

    private void OnEnable()
    {
        StartCoroutine(ColorShiftingCoroutine());
    }

    IEnumerator ColorShiftingCoroutine()
    {
        while (true)
        {
            int nextIndex = (currentIndex + 1) % rarityColors.Count;
        
            float timer = 0f;
            while (timer < transitionDuration)
            {
                timer += Time.deltaTime;
                _highlighter.color = Color.Lerp(rarityColors[currentIndex].color, rarityColors[nextIndex].color, timer / transitionDuration);
                _highlighter.color = new Color(_highlighter.color.r, _highlighter.color.g, _highlighter.color.b, 0.49f);
                yield return null;
            }

            _highlighter.color = rarityColors[nextIndex].color;
            _highlighter.color = new Color(_highlighter.color.r, _highlighter.color.g, _highlighter.color.b, 0.49f);
            currentIndex = nextIndex;
        
            yield return new WaitForSeconds(delayAfterTransition);
        }
    }
}
