using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using EngineRoom.Examples.Interfaces;
using UnityEngine;

namespace EngineRoom.Examples.Controllers
{
    public class TargetController : ITargetController, IDisposable
    {
        public event Action TargetGotHit;
        public event Action TargetDespawned;
        
        public bool CanSpawnTarget => !_view.HasTarget 
                                      && Time.time - _lastTimeDespawned >= _gameSettings.TargetSpawnCooldownInSeconds;
        
        private readonly IGameSettings _gameSettings;
        
        private ITargetView _view;
        private float _lastTimeDespawned;
        private CancellationTokenSource _despawnCancellationSource;

        public TargetController(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }
        
        public void SetView(ITargetView view)
        {
            if(_view != null)
            {
                _view.TargetGotHit -= OnTargetGotHit;
            }
            
            _view = view;
            _view.TargetGotHit += OnTargetGotHit;
            _lastTimeDespawned = Time.time - _gameSettings.TargetSpawnCooldownInSeconds;
        }

        public void SpawnTarget()
        {
            if(!CanSpawnTarget)
            {
                return;
            }
            
            CancelDespawnTimer();
            _view.SpawnTarget();
            
            _despawnCancellationSource = new CancellationTokenSource();
            DespawnAfterDelay(_gameSettings.DespawnTargetAfterSeconds, _despawnCancellationSource.Token).Forget();
        }
        
        private void OnTargetGotHit()
        {
            Despawn();
            TargetGotHit?.Invoke();
        }

        private void Despawn()
        {
            _lastTimeDespawned = Time.time;
            _view.DespawnTarget();
            CancelDespawnTimer();
        }
        
        private async UniTaskVoid DespawnAfterDelay(float seconds, CancellationToken token)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(seconds), cancellationToken: token);
                if (token.IsCancellationRequested || !_view.HasTarget)
                {
                    return;
                }

                Despawn();
                TargetDespawned?.Invoke();
            }
            catch (OperationCanceledException)
            {
                // ignored: countdown canceled (e.g., target got hit)
            }
        }

        private void CancelDespawnTimer()
        {
            _despawnCancellationSource?.Cancel();
            _despawnCancellationSource?.Dispose();
            _despawnCancellationSource = null;
        }

        public void Dispose()
        {
            _view.TargetGotHit -= OnTargetGotHit;
            CancelDespawnTimer();
        }
    }
}