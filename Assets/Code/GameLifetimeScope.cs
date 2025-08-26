using EngineRoom.Examples.Controllers;
using EngineRoom.Examples.Handlers;
using EngineRoom.Examples.Interfaces;
using EngineRoom.Examples.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace EngineRoom.Examples
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private ControlsSettings _controlsSettings;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Various
            builder.Register<IInputHandler, KeyboardInputHandler>(Lifetime.Singleton);
            
            // Settings
            builder.RegisterInstance(_controlsSettings).As<IControlsSettings>();
            
            builder.UseEntryPoints(config =>
            {
                config.Add<PlayerController>();
            });
        }
    }
}