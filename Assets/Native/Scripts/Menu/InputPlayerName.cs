using System;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPlayerName : MonoBehaviour
{
    [SerializeField] private string _defaultPlayerName;
    [SerializeField] private TMP_InputField _inputPlayerName;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _textAria;
    [SerializeField] private GameObject _textArea;
    
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;
    [SerializeField] private string _ar;
    [SerializeField] private string _ja;
    [SerializeField] private string _de;
    [SerializeField] private string _es;
    
    private void Start()
    {
        _textArea.SetActive(false);
        _nameText.gameObject.SetActive(true);
        _inputPlayerName.characterLimit = 12;
        
        var currentLanguage = PlayerPrefs.GetString("currentLanguage");
        // Russian
        if (currentLanguage == "ru")
        {
            _defaultPlayerName = _ru;
        }
        // Turkish
        else if (currentLanguage == "tr")
        {
            _defaultPlayerName = _tr;
        }
        // Arabic
        else if (currentLanguage == "ar")
        {
            _defaultPlayerName = _ar;
        }
        // Japanese
        else if (currentLanguage == "ja")
        {
            _defaultPlayerName = _ja;
        }
        // German
        else if (currentLanguage == "de")
        {
            _defaultPlayerName = _de;
        }
        // Spanish
        else if (currentLanguage == "es")
        {
            _defaultPlayerName = _es;
        }
        // English
        else
        {
            _defaultPlayerName = _en;
        }
        
        if (!PlayerPrefs.HasKey("playerName"))
        {
            _inputPlayerName.text = _defaultPlayerName;
            _nameText.text = _inputPlayerName.text;
        }
        else
        {
            _inputPlayerName.text = PlayerPrefs.GetString("playerName");
            _nameText.text = _inputPlayerName.text;
        }
    }

    public void onSubmit()
    {
        if (EventSystem.current.alreadySelecting == false)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
    
    public void onSelect()
    {
        _textArea.SetActive(true);
        _nameText.gameObject.SetActive(false);
    }
    
    public void onDeselect()
    {
        if (string.IsNullOrWhiteSpace(_inputPlayerName.text))
        {
            _inputPlayerName.text = _nameText.text;
        }
        else
        {
            PlayerPrefs.SetString("playerName", _inputPlayerName.text);
            PlayerPrefs.Save();
            _nameText.text = _inputPlayerName.text;
        }
        _textArea.SetActive(false);
        _nameText.gameObject.SetActive(true);
    }

}
