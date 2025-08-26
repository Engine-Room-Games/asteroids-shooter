using EngineRoom.Examples.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace EngineRoom.Examples.Controllers
{
    public class PlayerController : IPlayerController, ITickable
    {
        private readonly IInputHandler _inputHandler;

        public PlayerController(
            IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void Tick()
        {
            if(!Mathf.Approximately(_inputHandler.AimDirection, 0f))
            {
                Debug.Log($"Aim Direction: {_inputHandler.AimDirection}");
            }

            if (_inputHandler.IsFireButtonPressed)
            {
                Debug.Log("Fire Button Pressed");
            }
        }
    }
}