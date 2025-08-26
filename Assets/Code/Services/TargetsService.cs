using System;
using System.Collections.Generic;
using System.Linq;
using EngineRoom.Examples.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace EngineRoom.Examples.Services
{
    public class TargetsService : IStartable, IDisposable
    {
        private readonly ITimeService _timeService;
        private readonly ITargetView[] _spawnPoints;
        private readonly ITargetController[] _spawnPointControllers;
        private readonly IObjectResolver _resolver;

        public TargetsService(
            ITimeService timeService, 
            IEnumerable<ITargetView> spawnPoints,
            IObjectResolver resolver)
        {
            _timeService = timeService;
            _spawnPoints = spawnPoints!.ToArray();
            _spawnPointControllers = new ITargetController[_spawnPoints.Length];
            _resolver = resolver;
        }
        
        public void Start()
        {
            _timeService.SecondPassed += OnSecondPassed;

            for (var i = 0; i < _spawnPoints.Length; i++)
            {
                var targetSpawnPoint = _spawnPoints[i];
                
                var controller = _resolver.Resolve<ITargetController>();
                controller.SetView(targetSpawnPoint);
                
                controller.TargetGotHit += OnTargetGotHit;
                controller.TargetDespawned += OnTargetDespawned;
                
                _spawnPointControllers[i] = controller;
            }
        }

        private void OnTargetDespawned()
        {
            Debug.Log("Target Despawned");
        }

        private void OnTargetGotHit()
        {
            Debug.Log("Target GotHit");
        }

        private void OnSecondPassed()
        {
            var availableControllers = _spawnPointControllers.Where(c => c.CanSpawnTarget).ToArray();
            var index = Random.Range(0, availableControllers.Length);
            
            if (availableControllers.Length > 0)
            {
                availableControllers[index].SpawnTarget();
            }
        }

        public void Dispose()
        {
            _timeService.SecondPassed -= OnSecondPassed;

            foreach (var controller in _spawnPointControllers)
            {
                controller.TargetGotHit -= OnTargetGotHit;
                controller.TargetDespawned -= OnTargetDespawned;
            }
        }
    }
}