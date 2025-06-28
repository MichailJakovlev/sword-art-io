using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioState : MonoBehaviour, IAudioState
{
    [SerializeField] private AudioMixer _audioMixer;
    private bool _isEnableAuio;

    private IAudioState _audioState;
    AudioState IAudioState.AudioState => this;

    private void Start()
    {
        if (PlayerPrefs.GetString("Audio") == "Enable")
        {
            AudioSwitch(true);
        }
        else
        {
            AudioSwitch(false);
        }
    }

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
            StartAudio();
        }
        else
        {
            _isEnableAuio = false;
            PlayerPrefs.SetString("Audio", "Disable");
            PlayerPrefs.Save();
            StopAudio();
        }
    }

    public void StopAudio()
    {
        _audioMixer.SetFloat("MasterVolume", -80f);
    }

    public void StartAudio()
    {
        if (_isEnableAuio)
        {
            _audioMixer.SetFloat("MasterVolume", 0f);
        }
    }
}
    