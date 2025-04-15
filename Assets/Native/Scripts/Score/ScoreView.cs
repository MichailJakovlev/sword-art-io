using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScoreView : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI _playerScore;
    [SerializeField] private List<TextMeshProUGUI> _inspectText;
    
    private static List<TextMeshProUGUI> _scoreTexts;
    private static TextMeshProUGUI _playerScoreText;
    private Enemy _enemy;
    private Player _player;
    
    public Dictionary<string, int> score = new Dictionary<string, int>();
    
    void Start()
    {
        _scoreTexts = _inspectText;
        _playerScoreText = _playerScore;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        for (int i = 0; i < EnemyPool.enemyArray.Length + 1; i++)
        {
            if (i < EnemyPool.enemyArray.Length)
            {
                _enemy = EnemyPool.enemyArray[i].GetComponent<Enemy>();
                var name = (EnemyNames)i;
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
                if (item.Key == "Гитлер")
                {
                    _scoreTexts[i].fontStyle = FontStyles.Bold;
                }
                else
                {
                    _scoreTexts[i].fontStyle = FontStyles.Normal;
                }
                _scoreTexts[i].text = item.Key + " : " + item.Value;
                i++;
            }   
        }
        _playerScoreText.text = score["Гитлер"].ToString();
    }
}
