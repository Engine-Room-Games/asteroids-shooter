using EngineRoom.Examples.Interfaces;
using UnityEngine;

namespace EngineRoom.Examples.Views
{
    public class PlayerView : MonoBehaviour, IPlayerView
    { 
        public float CannonRotation 
        { 
            get => _cannon.eulerAngles.z;
            set => _cannon.eulerAngles = new Vector3(0f, 0f, value);
        }

        [SerializeField] private Transform _cannon;
    }
}