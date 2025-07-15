using System.Collections;
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
   public Canvas _scoreCanvas;
  
   private CoinCounter _coinCounter;
   private Player _player;
   private SceneState _sceneState;
   private Leaderboard _leaderboard;
   
   void Start()
   {
      _player = FindFirstObjectByType<Player>();
      _sceneState = FindFirstObjectByType<SceneState>();
      _leaderboard = FindObjectOfType<Leaderboard>();
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
      _leaderboard.SetPlayerScore(PlayerPrefs.GetInt("playerScoreRecord"));
      StartCoroutine(CoinTextAnimation());
   }
   public void RespawnPlayer()
   {
      _player.Respawn();
   }

   public void ExitToMainMenu()
   {
      _sceneState.ToMenuScene();
   }

   private IEnumerator CoinTextAnimation()
   {
      for (int i = 0; i < 40; i++)
      {   
         _coinsText.fontSize  += 0.5f;
         _coinsShadow.fontSize  += 0.5f;
         yield return new WaitForSeconds(0.01f);
      }
      for (int i = 0; i < 40; i++)
      {
         _coinsText.fontSize  -= 0.5f;
         _coinsShadow.fontSize  -= 0.5f;
         yield return new WaitForSeconds(0.01f);
      }
   }
}
