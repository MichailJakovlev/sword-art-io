using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public List<IScorable> _scoreList;

    void Start()
    {
        _scoreList = new List<IScorable>();
    }

    public void ResortList()
    {
        
    }
}
