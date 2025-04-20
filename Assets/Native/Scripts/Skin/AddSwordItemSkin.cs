using System.Collections.Generic;
using UnityEngine;
public class AddSwordItemSkin : MonoBehaviour
{
    public List<GameObject> _skins = new List<GameObject>();
    public Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        switch (_player.skin)
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
        }
    }
}
