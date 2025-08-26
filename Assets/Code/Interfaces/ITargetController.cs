using System;

namespace EngineRoom.Examples.Interfaces
{
    public interface ITargetController
    {
        event Action TargetGotHit;
        event Action TargetDespawned;
        bool CanSpawnTarget { get; }
        void SetView(ITargetView view);
        void SpawnTarget();
    }
}