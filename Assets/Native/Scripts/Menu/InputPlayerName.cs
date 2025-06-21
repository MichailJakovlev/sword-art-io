using System;
using TMPro;
using UnityEngine;

public class InputPlayerName : MonoBehaviour
{
    [SerializeField] private string _defaultPlayerName;
    [SerializeField] private TMP_InputField _inputPlayerName;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("playerName"))
        {
            _inputPlayerName.text = _defaultPlayerName;
        }
        else
        {
            _inputPlayerName.text = PlayerPrefs.GetString("playerName");
        }
    }

    public void EnterPlayerName()
    {
        if (_inputPlayerName.isFocused == true)
        {
            Debug.Log("focus lost");
        }
        PlayerPrefs.SetString("playerName", _inputPlayerName.text);
        PlayerPrefs.Save();
    }

    public void FocusOutEvent()
    {
        
        
    }
}
