namespace EngineRoom.Examples.Interfaces
{
    public interface IGameSettings
    {
        int PointsPerHit { get; }
        int PointsPerMiss { get; }
        float AimRotationDegreesPerSecond { get; }
        float DespawnTargetAfterSeconds { get; }
        float TargetSpawnCooldownInSeconds { get; }
    }
}