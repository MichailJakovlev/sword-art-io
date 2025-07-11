using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private EventBus _eventBus;
    [SerializeField] private GameState _gameState;
    [SerializeField] private SceneState _sceneState;
    [SerializeField] private AudioState _audioState;
    [SerializeField] private Authorization _authorization;
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private RewardAd _rewardAd;
    [SerializeField] private FullscreenAd _fullscreenAd;
    [SerializeField] private RateGame _rateGame;
    [SerializeField] private ReadyGameAPI _readyGameAPI;
    [SerializeField] private UISwitcher _uiSwitcher;
    [SerializeField] private Player _player;
    [SerializeField] private SwordPool _swordPool;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private ItemPool _itemPool;
    
    [SerializeField] private AudioData _audioData;
    
    public override void InstallBindings()
         {
             Application.targetFrameRate = 1000;
             QualitySettings.vSyncCount = 0;
             
        EventBus eventBus = Container.InstantiatePrefabForComponent<EventBus>(_eventBus, _eventBus.transform.position, Quaternion.identity, null);
        Container.Bind<IEventBus>().To<EventBus>().FromInstance(eventBus).AsSingle();

        GameState gameState = Container.InstantiatePrefabForComponent<GameState>(_gameState, _gameState.transform.position, Quaternion.identity, null);
        Container.Bind<IGameState>().To<GameState>().FromInstance(gameState).AsSingle();
        
        AudioData audioData = Container.InstantiatePrefabForComponent<AudioData>(_audioData, _audioData.transform.position, Quaternion.identity, null);
        Container.Bind<AudioData>().FromInstance(audioData).AsSingle();

        SceneState sceneState = Container.InstantiatePrefabForComponent<SceneState>(_sceneState, _sceneState.transform.position, Quaternion.identity, null);
        Container.Bind<ISceneState>().To<SceneState>().FromInstance(sceneState).AsSingle();

        AudioState audioState = Container.InstantiatePrefabForComponent<AudioState>(_audioState, _audioState.transform.position, Quaternion.identity, null);
        Container.Bind<IAudioState>().To<AudioState>().FromInstance(audioState).AsSingle();

        Authorization authorization = Container.InstantiatePrefabForComponent<Authorization>(_authorization, _authorization.transform.position, Quaternion.identity, null);
        Container.Bind<IAuthorization>().To<Authorization>().FromInstance(authorization).AsSingle();

        Leaderboard leaderboard = Container.InstantiatePrefabForComponent<Leaderboard>(_leaderboard, _leaderboard.transform.position, Quaternion.identity, null);
        Container.Bind<ILeaderboard>().To<Leaderboard>().FromInstance(leaderboard).AsSingle();

        RewardAd rewardAd = Container.InstantiatePrefabForComponent<RewardAd>(_rewardAd, _rewardAd.transform.position, Quaternion.identity, null);
        Container.Bind<IRewardAd>().To<RewardAd>().FromInstance(rewardAd).AsSingle();

        FullscreenAd fullsceenAd = Container.InstantiatePrefabForComponent<FullscreenAd>(_fullscreenAd, _fullscreenAd.transform.position, Quaternion.identity, null);
        Container.Bind<IFullscreenAd>().To<FullscreenAd>().FromInstance(fullsceenAd).AsSingle();

        RateGame rateGame = Container.InstantiatePrefabForComponent<RateGame>(_rateGame, _rateGame.transform.position, Quaternion.identity, null);
        Container.Bind<IRateGame>().To<RateGame>().FromInstance(rateGame).AsSingle();
        
        EnemyPool enemyPool = Container.InstantiatePrefabForComponent<EnemyPool>(_enemyPool, _enemyPool.transform.position, Quaternion.identity, null);
        Container.Bind<IEnemyPool>().To<EnemyPool>().FromInstance(enemyPool).AsSingle().NonLazy();
        
        Player player = Container.InstantiatePrefabForComponent<Player>(_player, new Vector3(Random.Range(GameData.X * -1 + 15, GameData.X - 15), 0, Random.Range(GameData.Z * -1 + 15, GameData.Z - 15)), Quaternion.identity, null);
        Container.Bind<IPlayer>().To<Player>().FromInstance(player).AsSingle().NonLazy();
        
        SwordPool swordPool = Container.InstantiatePrefabForComponent<SwordPool>(_swordPool, player.transform.position, Quaternion.identity, player.transform);
        Container.Bind<ISwordPool>().To<SwordPool>().FromInstance(swordPool).AsTransient().NonLazy();
        
        ItemPool itemPool = Container.InstantiatePrefabForComponent<ItemPool>(_itemPool, transform.position, Quaternion.identity, null);
        Container.Bind<IItemPool>().To<ItemPool>().FromInstance(itemPool).AsSingle().NonLazy();

        ReadyGameAPI readyGameAPI = Container.InstantiatePrefabForComponent<ReadyGameAPI>(_readyGameAPI, _readyGameAPI.transform.position, Quaternion.identity, null);
        Container.Bind<IReadyGameAPI>().To<ReadyGameAPI>().FromInstance(readyGameAPI).AsSingle();

        UISwitcher uiSwitcher = Container.InstantiatePrefabForComponent<UISwitcher>(_uiSwitcher, _uiSwitcher.transform.position, Quaternion.identity, null);
    }    
}

