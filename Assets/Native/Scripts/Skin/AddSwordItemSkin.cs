using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddSwordItemSkin : MonoBehaviour
{
    public List<GameObject> _skins = new List<GameObject>();
    public Player _player;
    private GameConfig _gameConfig;
    private ISaveData _saveData;
    private string _skinName;

    [Inject]
    private void Construct(GameConfig gameConfig, ISaveData saveData)
    {
        _gameConfig = gameConfig;
        _saveData = saveData;
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
        if (_player == null)
        {
            _skinName = MenuCurrentSkin._skinWeaponName;
        }
        else
        {
            _skinName = _player.skin;
            Debug.Log(_player.skin);
        }
        
        switch (_skinName)
        {
            case "Guts":
                _skins[0].SetActive(true);
                break;
            case "Jason":
                _skins[1].SetActive(true);
                break;
            case "King":
                _skins[2].SetActive(true);
                break;
            case "Knight":
                _skins[3].SetActive(true);
                break;
            case "Ninja":
                _skins[4].SetActive(true);
                break;
            case "Orc":
                _skins[5].SetActive(true);
                break;
            case "Pirate":
                _skins[6].SetActive(true);
                break;
            case "Reaper":
                _skins[7].SetActive(true);
                break;
            case "Samurai":
                _skins[8].SetActive(true);
                break;
            case "Vader":
                _skins[9].SetActive(true);
                break;
            case "Viking":
                _skins[10].SetActive(true);
                break;
            case "Ekko":
                _skins[11].SetActive(true);
                break;
            case "Cavalier":
                _skins[12].SetActive(true);
                break;
            case "Aang":
                _skins[13].SetActive(true);
                break;
            case "Witcher":
                _skins[14].SetActive(true);
                break;
            case "Puss":
                _skins[15].SetActive(true);
                break;
            case "Templar":
                _skins[16].SetActive(true);
                break;
            case "Namu":
                _skins[17].SetActive(true);
                break;
        }
    }
}
