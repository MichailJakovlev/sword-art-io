using UnityEngine;
using UnityEngine.Audio;

public class AudioState : MonoBehaviour, IAudioState
{
    [SerializeField] private AudioMixer _audioMixer;
    private bool _isEnableAuio;

    private IAudioState _audioState;
    AudioState IAudioState.AudioState => this;

    private void OnEnable()
    {
        EventBus.StartGame += StartAudio;
        EventBus.StopGame += StopAudio;
    }

    private void OnDisable()
    {
        EventBus.StartGame -= StartAudio;
        EventBus.StopGame -= StopAudio;
    }

    public void AudioSwitch(bool audioSwitch)
    {
        if(audioSwitch)
        {
            _isEnableAuio = true;
            PlayerPrefs.SetString("Audio", "Enable");
            PlayerPrefs.Save();
        }
        else
        {
            _isEnableAuio = false;
            PlayerPrefs.SetString("Audio", "Disable");
            PlayerPrefs.Save();
        }
    }

    public void StopAudio()
    {
        // AudioMixer Disable Method
    }

    public void StartAudio()
    {
        if (_isEnableAuio)
        {
            // AudioMixer Enable Method
        }
    }
}
    