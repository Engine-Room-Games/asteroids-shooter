using System;
using EngineRoom.Examples.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace EngineRoom.Examples.Services
{
    public class TimeService : ITimeService, ITickable
    {
        public event Action SecondPassed;
        
        public int SecondsPassed { get; private set; }

        private float _elapsedTime;

        public void Tick()
        {
            _elapsedTime += Time.deltaTime;
            
            if (_elapsedTime < 1f)
            {
                return;
            }
            
            _elapsedTime = 0f;
            SecondsPassed++;
            SecondPassed?.Invoke();
        }
    }
}