using System;
using EngineRoom.Examples.Interfaces;

namespace EngineRoom.Examples.Services
{
    public class ScoreService : IScoreService
    {
        public event Action<int> ScoreChanged;
        
        public int CurrentScore { get; private set; }
        
        private readonly IGameSettings _gameSettings;

        public ScoreService(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }
        
        public void AddScore()
        {
            CurrentScore += _gameSettings.PointsPerHit;
            ScoreChanged?.Invoke(CurrentScore);
        }

        public void SubtractScore()
        {
            CurrentScore += _gameSettings.PointsPerMiss;
            ScoreChanged?.Invoke(CurrentScore);
        }
    }
}