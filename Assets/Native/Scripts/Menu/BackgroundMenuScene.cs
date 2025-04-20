using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundMenuScene : MonoBehaviour, IBackgroundMenuScene
{
    BackgroundMenuScene IBackgroundMenuScene.BackgroundMenuScene => this;
}