using EngineRoom.Examples.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace EngineRoom.Examples.Controllers
{
    public class PlayerController : IPlayerController, ITickable
    {
        private readonly IInputHandler _inputHandler;
        private readonly IGameSettings _gameSettings;
        private readonly IPlayerView _playerView;

        public PlayerController(
            IInputHandler inputHandler,
            IGameSettings gameSettings, 
            IPlayerView playerView)
        {
            _inputHandler = inputHandler;
            _gameSettings = gameSettings;
            _playerView = playerView;
        }

        public void Tick()
        {
            if(!Mathf.Approximately(_inputHandler.AimDirection, 0f))
            {
                _playerView.CannonRotation += _gameSettings.AimRotationDegreesPerSecond * Time.deltaTime * _inputHandler.AimDirection;
            }

            if (_inputHandler.IsFireButtonPressed)
            {
                Debug.Log("Fire Button Pressed");
            }
        }
    }
}