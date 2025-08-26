using UnityEngine;

namespace EngineRoom.Examples.Interfaces
{
    public interface IControlsSettings
    {
        KeyCode AimLeftKey { get; }
        KeyCode AimRightKey { get; }
        KeyCode FireKey { get; }
    }
}