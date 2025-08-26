using EngineRoom.Examples.Interfaces;
using EngineRoom.Examples.Utils;
using EngineRoom.Examples.Views;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace EngineRoom.Examples.Services
{
    public class BulletsService : IBulletsService
    {
        private readonly BulletView _bulletPrefab;
        private readonly IObjectResolver _resolver;
        private readonly Transform _bulletSpawnPoint;
        private readonly ObjectPool<BulletView> _pool;

        public BulletsService(
            BulletView bulletPrefab,
            IObjectResolver resolver,
            [Key(TransformKey.BulletSpawn)] Transform bulletSpawnPoint)
        {
            _bulletPrefab = bulletPrefab;
            _resolver = resolver;
            _bulletSpawnPoint = bulletSpawnPoint;
            _pool = new ObjectPool<BulletView>(CreateBullet, OnSpawned, OnReleased);
        }

        public void SpawnBullet(Vector2 direction)
        {
            var bullet = _pool.Get();
            bullet.SetMovementDirection(direction);
        }

        public void DespawnBullet(BulletView bullet) => _pool.Release(bullet);
        private void OnReleased(BulletView bullet) => bullet.gameObject.SetActive(false);

        private void OnSpawned(BulletView bullet)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = _bulletSpawnPoint.position;
        }
        private BulletView CreateBullet() => _resolver.Instantiate(_bulletPrefab);
    }
}