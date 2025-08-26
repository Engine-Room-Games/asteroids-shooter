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
        private readonly IBulletsService _bulletsService;

        public PlayerController(
            IInputHandler inputHandler,
            IGameSettings gameSettings, 
            IPlayerView playerView,
            IBulletsService bulletsService)
        {
            _inputHandler = inputHandler;
            _gameSettings = gameSettings;
            _playerView = playerView;
            _bulletsService = bulletsService;
        }

        public void Tick()
        {
            if(!Mathf.Approximately(_inputHandler.AimDirection, 0f))
            {
                _playerView.CannonRotation += _gameSettings.AimRotationDegreesPerSecond * Time.deltaTime * _inputHandler.AimDirection;
            }

            if (_inputHandler.IsFireButtonPressed)
            {
                var aimDirection = Quaternion.Euler(0f, 0f, _playerView.CannonRotation) * Vector2.right;
                _bulletsService.SpawnBullet(aimDirection);
            }
        }
    }
}