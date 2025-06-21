using System.Runtime.InteropServices;
using UnityEngine;

public class RewardAd : MonoBehaviour, IRewardAd
{
    [DllImport("__Internal")]
    public static extern void ShowReward(int num);

    private IRewardAd _rewardAd;

    RewardAd IRewardAd.RewardAd => this;

    public void ShowRewardAd(int num)
    {
        ShowReward(num);
    }

    public void RewardAdWatched(int num)
    {
        switch (num)
        {
            case 1: 
                FindFirstObjectByType<CaseOpenAnimation>().Play();
                FindFirstObjectByType<CaseOpener>().OpenCase();
                FindFirstObjectByType<CaseScreeen>().HideUI();
                break;
            case 2:
                FindFirstObjectByType<CoinCounter>().DubbleCoins();
                FindFirstObjectByType<GameOverMenu>().Show(FindFirstObjectByType<Player>().score);
                break;
            case 3:
                // 3st award method
                break;
            case 4:
                // 4st award method
                break;
        }
    }
}
