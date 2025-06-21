using UnityEngine;

public class LeaderboardContent : MonoBehaviour
{
    [SerializeField] private LeaderboardItem _itemPrefab;
    private GameObject item;

    public void Fill(string name, string score, string rank)
    {
        _itemPrefab._playerName.text = name;
        _itemPrefab._playerScore.text = score;
        _itemPrefab._playerRank.text = rank;
        _itemPrefab._playerRankShadow.text = rank;
        _itemPrefab._playerNameShadow.text = name;
        _itemPrefab._playerScoreShadow.text = score;    
        item = Instantiate(_itemPrefab.gameObject, transform.position, Quaternion.identity, transform);
    }
}
