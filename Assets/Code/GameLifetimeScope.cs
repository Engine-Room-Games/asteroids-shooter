using EngineRoom.Examples.Controllers;
using EngineRoom.Examples.Handlers;
using EngineRoom.Examples.Interfaces;
using EngineRoom.Examples.Settings;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Various
            builder.Register<IInputHandler, KeyboardInputHandler>(Lifetime.Singleton);
            
            // Settings
            builder.RegisterInstance(_controlsSettings).As<IControlsSettings>();
            builder.RegisterInstance<IGameSettings>(_gameSettings);
            
            // Views
            builder.RegisterComponent(_playerView).As<IPlayerView>();
            
            builder.UseEntryPoints(config =>
            {
                config.Add<PlayerController>();
            });
        }
    }
}