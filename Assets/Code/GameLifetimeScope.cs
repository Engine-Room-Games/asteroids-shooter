using EngineRoom.Examples.Controllers;
using EngineRoom.Examples.Handlers;
using EngineRoom.Examples.Interfaces;
using EngineRoom.Examples.Services;
using EngineRoom.Examples.Settings;
using EngineRoom.Examples.Utils;
using EngineRoom.Examples.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace EngineRoom.Examples
{
    public class GameLifetimeScope : LifetimeScope
    {
        
        [Header("Settings")]
        [SerializeField] private ControlsSettings _controlsSettings;
        [SerializeField] private GameSettings _gameSettings;
        
        [Header("Views")] 
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private BulletView _bulletViewPrefab;
        [SerializeField] private TargetView[] _targetSpawnPointViews;
        
        [Header("Various")]
        [SerializeField] private Transform _bulletSpawnPoint;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Services
            builder.Register<IBulletsService, BulletsService>(Lifetime.Singleton);
            
            // Various
            builder.Register<IInputHandler, KeyboardInputHandler>(Lifetime.Singleton);
            builder.RegisterInstance(_bulletSpawnPoint).Keyed(TransformKey.BulletSpawn);
            builder.Register<ITargetController, TargetController>(Lifetime.Transient);
            
            // Settings
            builder.RegisterInstance(_controlsSettings).As<IControlsSettings>();
            builder.RegisterInstance<IGameSettings>(_gameSettings);
            
            // Views
            builder.RegisterComponent(_playerView).As<IPlayerView>();
            builder.RegisterInstance(_bulletViewPrefab);

            foreach (var targetSpawnPointView in _targetSpawnPointViews)
            {
                builder.RegisterInstance<ITargetView>(targetSpawnPointView)
                    .Keyed(targetSpawnPointView.name);
            }
            
            builder.UseEntryPoints(config =>
            {
                config.Add<PlayerController>();
                config.Add<TargetsService>();
                config.Add<TimeService>().As<ITimeService>();
            });
        }
    }
}