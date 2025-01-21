using System.Runtime.InteropServices;
using UnityEngine;

public class RateGame : MonoBehaviour, IRateGame
{
    [DllImport("__Internal")]
    public static extern void CallRateGame();

    private IRateGame _rateGame;
    RateGame IRateGame.RateGame => this;

    public void OpenRateGamePage()
    {
      //  CallRateGame();
    }

    public void GetRateGameAward()
    {
        // Award method
    }
}
