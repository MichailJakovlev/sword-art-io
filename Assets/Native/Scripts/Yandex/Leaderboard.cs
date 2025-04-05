using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Leaderboard : MonoBehaviour, ILeaderboard
{
    [DllImport("__Internal")]
    public static extern void SetScoreLeaderboard(int record);

    [DllImport("__Internal")]
    public static extern void GetScoreLeaderboard();

    private ILeaderboard _leaderboard;
    public GameObject GameObject => gameObject;
    Leaderboard ILeaderboard.Leaderboard => this;

    [SerializeField] private LeaderboardContent _leaderboardContent;

    private bool _isLeaderboardClear;
    private bool _isPlayerAuthed;

    [System.Serializable]
    public class PlayerJson
    {
        public int rank;
        public string playerName;
        public int score;
    }

    [System.Serializable]
    public class PlayerJsonArray
    {
        public PlayerJson[] entries;
    }

    public void Start()
    {
        _isLeaderboardClear = true;
        _isPlayerAuthed = false;
    }

    private void OnEnable()
    {
        EventBus.AuthPlayer += AuthCheck;
    }

    private void OnDisable()
    {
        EventBus.AuthPlayer -= AuthCheck;
    }

    public void AuthCheck(int authStatus)
    {
        if (authStatus > 0)
        {
            _isPlayerAuthed = true;
        }
        else
        {
            _isPlayerAuthed = false;
        }
    }                   
  
    public void GetPlayers(string lbAnswer)
    {
        PlayerJsonArray playerArray = JsonUtility.FromJson<PlayerJsonArray>(lbAnswer);

        for (int i = 0; i < playerArray.entries.Length; i++)
        {
            _leaderboardContent.Fill(playerArray.entries[i].playerName.ToString(), playerArray.entries[i].score.ToString(), playerArray.entries[i].rank.ToString());
        }
    }

    public void SetPlayerScore(int record)
    {
        if (_isPlayerAuthed)
        {
            SetScoreLeaderboard(record);
        }
    }

    public void OpenLeaderboard()
    {
        if (_isLeaderboardClear)
        {
            GetScoreLeaderboard();
            _isLeaderboardClear = false;
        }
    }

    public void AuthGetScore()
    {
        GetScoreLeaderboard();
    }
}
