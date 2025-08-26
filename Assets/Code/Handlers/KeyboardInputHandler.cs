using EngineRoom.Examples.Interfaces;
using UnityEngine;

namespace EngineRoom.Examples.Handlers
{
    public class KeyboardInputHandler : IInputHandler
    {
        public float AimDirection => GetAimDirection();
        public bool IsFireButtonPressed => Input.GetKeyDown(_controlsSettings.FireKey);
        
        private readonly IControlsSettings _controlsSettings;

        public KeyboardInputHandler(IControlsSettings controlsSettings)
        {
            _controlsSettings = controlsSettings;
        }
        
        private float GetAimDirection()
        {
            return Input.anyKey switch
            {
                true when Input.GetKey(_controlsSettings.AimLeftKey) => 1f,
                true when Input.GetKey(_controlsSettings.AimRightKey) => -1f,
                _ => 0f
            };
        }
    }
}