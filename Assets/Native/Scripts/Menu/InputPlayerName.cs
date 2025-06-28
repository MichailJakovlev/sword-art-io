using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPlayerName : MonoBehaviour
{
    [SerializeField] private string _defaultPlayerName;
    [SerializeField] private TMP_InputField _inputPlayerName;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private GameObject _textArea;
    
    private void Start()
    {
        _textArea.SetActive(false);
        _nameText.gameObject.SetActive(true);
        _inputPlayerName.characterLimit = 12;
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
        Debug.Log("select");
    }
    
    public void onDeselect()
    {
        PlayerPrefs.SetString("playerName", _inputPlayerName.text);
        PlayerPrefs.Save();
        _nameText.text = _inputPlayerName.text;
        _textArea.SetActive(false);
        _nameText.gameObject.SetActive(true);
        
        Debug.Log("deselect");
    }

}
