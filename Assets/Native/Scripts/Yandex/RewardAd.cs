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
                // 1st award method
                break;
            case 2:
                // 2st award method
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
