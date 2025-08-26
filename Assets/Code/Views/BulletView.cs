using EngineRoom.Examples.Interfaces;
using UnityEngine;
using VContainer;

namespace EngineRoom.Examples.Views
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;

        private IBulletsService _bulletsService;
        private Vector2 _moveDirection = Vector2.right;
        
        [Inject]
        public void Construct(IBulletsService bulletsService)
        {
            _bulletsService = bulletsService;
        }

        private void OnEnable() => StartMovement();
        private void OnTriggerEnter2D(Collider2D other) => _bulletsService.DespawnBullet(this);

        public void SetMovementDirection(Vector2 direction)
        {
            _moveDirection = direction;
            StartMovement();
        }

        private void StartMovement()
        {
            _rigidbody.linearVelocity = _moveDirection.normalized * _speed;
            var angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}