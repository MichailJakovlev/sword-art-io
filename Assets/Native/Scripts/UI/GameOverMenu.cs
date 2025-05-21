using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _scoreText;
   [SerializeField] private TextMeshProUGUI _scoreTextShadow;
   [SerializeField] private TextMeshProUGUI _recordScoreText;
   [SerializeField] private TextMeshProUGUI _recordScoreShadow;
   [SerializeField] private TextMeshProUGUI _coinsText;
   [SerializeField] private TextMeshProUGUI _coinsShadow;
  
   private CoinCounter _coinCounter;
   private Player _player;
   private SceneState _sceneState;
   
   void Start()
   {
      _player = FindFirstObjectByType<Player>();
      _sceneState = FindFirstObjectByType<SceneState>();
   }

   public void Show(int score)
   {
      _coinCounter = FindFirstObjectByType<CoinCounter>();
      _scoreText.text = score.ToString();
      _scoreTextShadow.text = _scoreText.text;
      _recordScoreText.text = PlayerPrefs.GetInt("playerScoreRecord").ToString();
      _recordScoreShadow.text = _recordScoreText.text;
      _coinsText.text = _coinCounter.coins.ToString();
      _coinsShadow.text = _coinsText.text;

   }
   public void RespawnPlayer()
   {
      _player.Respawn();
   }

   public void ExitToMainMenu()
   {
      _sceneState.ToMenuScene();
   }
}
