using EngineRoom.Examples.Interfaces;
using UnityEngine;

namespace EngineRoom.Examples.Settings
{
    [CreateAssetMenu(fileName = "Controls Settings", menuName = "Engine Room/Controls Settings")]
    public class ControlsSettings : ScriptableObject, IControlsSettings
    {
        [field: SerializeField] public KeyCode AimLeftKey { get; set; } = KeyCode.A;
        [field:SerializeField] public KeyCode AimRightKey { get; set; } = KeyCode.D;
        [field:SerializeField] public KeyCode FireKey { get; set; } = KeyCode.Space;
    }
}