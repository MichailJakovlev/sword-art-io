using UnityEngine;
using Zenject;

public class UISwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _authRateGameButton;
    [SerializeField] private GameObject _rateGameButton;
    [SerializeField] private GameObject _audioEnableButton;
    [SerializeField] private GameObject _audioDisableButton;
    [SerializeField] private GameObject _menu;
    
    private ILeaderboard _leaderboard;
    private IAudioState _audioState;
    private IAuthorization _authorization;
    private GameObject _authLeaderboardPanel;
    
    public void Start()
    {
        AudioButtonSwitch();
    }

    [Inject]
    private void Cunstruct(ILeaderboard uileaderbord, IAudioState audioState, IAuthorization authorization)
    {
        _leaderboard = uileaderbord;
        _audioState = audioState;
        _authorization = authorization;
        
    }

    public void LeaderboardSwitch(bool leaderboardSwitch)
    {
        if (leaderboardSwitch)
        {
            _leaderboard.GameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            _leaderboard.GameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void LeaderboardToMenu()
    {
        _menu.SetActive(true);
        _authorization.GameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void AudioVolumeSwitch(bool audioSwitch)
    {
        _audioState.AudioState.AudioSwitch(audioSwitch);
    }

    public void AudioButtonSwitch()
    {
        if (PlayerPrefs.GetString("Audio") == "Enable")
        {
            _audioDisableButton.SetActive(true);
            _audioEnableButton.SetActive(false);
        }
        else
        {
            _audioDisableButton.SetActive(false);
            _audioEnableButton.SetActive(true);
        }
    }
}
