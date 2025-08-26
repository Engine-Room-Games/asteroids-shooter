using EngineRoom.Examples.Views;
using UnityEngine;

namespace EngineRoom.Examples.Interfaces
{
    public interface IBulletsService
    {
        void SpawnBullet(Vector2 direction);
        void DespawnBullet(BulletView bullet);
    }
}