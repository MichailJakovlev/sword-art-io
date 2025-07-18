using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Localization : MonoBehaviour
{
    // [DllImport("__Internal")]
    // public static extern string GetLang();

    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;
    [SerializeField] private string _ar;
    [SerializeField] private string _ja;
    [SerializeField] private string _de;
    [SerializeField] private string _es;

    [SerializeField] private TMP_FontAsset _arFont;
    [SerializeField] private TMP_FontAsset _jaFont;

    [HideInInspector] public string _currentLanguage;

    public void Start()
    {
        _currentLanguage = PlayerPrefs.GetString("currentLanguage");

        // Russian
        if (_currentLanguage == "ru")
        {
            GetComponent<TextMeshProUGUI>().text = _ru;
        }

        // Turkish
        else if (_currentLanguage == "tr")
        {
            GetComponent<TextMeshProUGUI>().text = _tr;
        }

        // Arabic
        else if (_currentLanguage == "ar")
        {
            GetComponent<TextMeshProUGUI>().text = _ar;
        }

        // Japanese
        else if (_currentLanguage == "ja")
        {
            GetComponent<TextMeshProUGUI>().text = _ja;
        }

        // German
        else if (_currentLanguage == "de")
        {
            GetComponent<TextMeshProUGUI>().text = _de;
        }

        // Spanish
        else if (_currentLanguage == "es")
        {
            GetComponent<TextMeshProUGUI>().text = _es;
        }

        // English
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
    }
}
