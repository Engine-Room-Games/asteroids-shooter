using System;

namespace EngineRoom.Examples.Interfaces
{
    public interface ITargetView
    {
        event Action TargetGotHit;
        
        bool HasTarget { get; }
        void SpawnTarget();
        void DespawnTarget();
    }
}