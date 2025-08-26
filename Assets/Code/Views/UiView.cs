using System;
using EngineRoom.Examples.Interfaces;
using TMPro;
using UnityEngine;
using VContainer;

namespace EngineRoom.Examples.Views
{
    public class UiView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timeText;

        private ITimeService _timeService;
        private IScoreService _scoreService;
        
        [Inject]
        public void Construct(ITimeService timeService, IScoreService scoreService)
        {
            _timeService = timeService;
            _scoreService = scoreService;
        }

        private void Awake()
        {
            _timeService.SecondPassed += OnSecondPassed;
            _scoreService.ScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int newScore)
        {
            _scoreText.text = $"Score: {newScore}";
        }

        private void OnSecondPassed()
        {
            var timePassed = TimeSpan.FromSeconds(_timeService.SecondsPassed);
            _timeText.text = $"Time: {timePassed:mm\\:ss}";
        }

        private void OnDestroy()
        {
            _timeService.SecondPassed -= OnSecondPassed;
            _scoreService.ScoreChanged -= OnScoreChanged;
        }
    }
}