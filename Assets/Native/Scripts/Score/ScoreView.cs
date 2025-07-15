using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScoreView : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI _playerScore;
    [SerializeField] private TextMeshProUGUI _playerScoreShadow;
    [SerializeField] private List<TextMeshProUGUI> _inspectText;
    [SerializeField] private List<TextMeshProUGUI> _inspectShadow;
    
    private static List<TextMeshProUGUI> _scoreTexts;
    private static List<TextMeshProUGUI> _scoreShadow;
    private static TextMeshProUGUI _playerScoreText;
    private static TextMeshProUGUI _playerScoreShadowText;
    private Enemy _enemy;
    private Player _player;
    private int lastPlayerScore = 0;
    private int minI = 0;
    private int maxI = 10;
    
    public Dictionary<string, int> score = new Dictionary<string, int>();
    
    void Start()
    {
        _scoreTexts = _inspectText;
        _scoreShadow = _inspectShadow;
        _playerScoreText = _playerScore;
        _playerScoreShadowText = _playerScoreShadow;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        for (int i = 0; i < EnemyPool.enemyArray.Length + 1; i++)
        {
            if (i < EnemyPool.enemyArray.Length)
            {
                _enemy = EnemyPool.enemyArray[i].GetComponent<Enemy>();
                if (i != 0)
                {
                    minI = i * 10 + 1;
                    maxI = minI + 9;
                }
                var name = (EnemyNames)Random.Range(minI, maxI);
                _enemy.name = name.ToString();
                _enemy.score = Random.Range(0, 25);
                score.Add(_enemy.name, _enemy.score);
            }
            else
            {
                score.Add(_player.name,  _player.score);
            }
        }
        ViewScore();
    }
    
    public void ViewScore()
    {
        var sortedScore = score.OrderByDescending(x => x.Value);
        score = sortedScore.ToDictionary(x => x.Key, x => x.Value);
        
        int i = 0;
        foreach (var item in score)
        {
            if (i < 5)
            {
                if (item.Key == PlayerPrefs.GetString("playerName"))
                {
                    _scoreTexts[i].fontStyle = FontStyles.Bold;
                    _scoreShadow[i].fontStyle = FontStyles.Bold;
                }
                else
                {
                    _scoreTexts[i].fontStyle = FontStyles.Normal;
                    _scoreShadow[i].fontStyle = FontStyles.Normal;
                }
                _scoreTexts[i].text = item.Key + " : " + item.Value;
                _scoreShadow[i].text = item.Key + " : " + item.Value;
                i++;
            }   
        }
        _playerScoreText.text = score[PlayerPrefs.GetString("playerName")].ToString();
        _playerScoreShadowText.text = score[PlayerPrefs.GetString("playerName")].ToString();

        if (lastPlayerScore != score[PlayerPrefs.GetString("playerName")])
        {
            PlayerScoreAnimation();
            lastPlayerScore = score[PlayerPrefs.GetString("playerName")];
        }
    }

    public void PlayerScoreAnimation()
    {
        StartCoroutine(CoinTextAnimation());
    }
    private IEnumerator CoinTextAnimation()
    {
        for (int i = 0; i < 40; i++)
        {   
            _playerScoreText.fontSize  += 0.5f;
            _playerScoreShadowText.fontSize  += 0.5f;
            yield return new WaitForSeconds(0.01f);
        }
    

        for (int i = 0; i < 40; i++)
        {
            _playerScoreText.fontSize  -= 0.5f;
            _playerScoreShadowText.fontSize  -= 0.5f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void PlayerScoreClean()
    {
        _playerScoreText.text = "0";
        _playerScoreShadowText.text = "0";
    }
}
