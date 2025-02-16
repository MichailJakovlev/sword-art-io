
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "ScriptableObjects/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller
{
    [SerializeField] public GameConfig gameConfig;

    public override void InstallBindings()
    {
        Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
    }
}
