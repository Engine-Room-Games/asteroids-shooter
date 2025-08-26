using System;
using EngineRoom.Examples.Interfaces;
using UnityEngine;

namespace EngineRoom.Examples.Views
{
    public class TargetView : MonoBehaviour, ITargetView
    {
        public event Action TargetGotHit;
        
        public bool HasTarget => _target.activeInHierarchy;

        [SerializeField] private GameObject _target;
        [SerializeField] private Collider2D _collider;
        
        private void Awake() => DespawnTarget();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!HasTarget)
            {
                return;
            }

            TargetGotHit?.Invoke();
        }
        
        public void SpawnTarget()
        {
            _target.SetActive(true);
            _collider.enabled = true;
        }

        public void DespawnTarget()
        {
            _target.SetActive(false);
            _collider.enabled = false;
        }
    }
}