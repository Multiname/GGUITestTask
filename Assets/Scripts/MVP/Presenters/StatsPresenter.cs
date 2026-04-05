using System;
using MVP.Models;
using MVP.Views.Content.Stats;
using Zenject;

namespace MVP.Presenters
{
    public class StatsPresenter : IDisposable, IInitializable
    {
        private readonly StatsModel _model;
        private readonly StatsLayoutView _statsLayoutView;

        [Inject]
        public StatsPresenter(
            StatsModel model,
            StatsLayoutView statsLayoutView
        )
        {
            _model = model;
            _statsLayoutView = statsLayoutView;
        }
        
        public void Initialize()
        {
            LoadStats();
            _model.OnStatsChanged += LoadStats;
        }
        
        public void Dispose()
        {
            _model.OnStatsChanged -= LoadStats;
        }

        private void LoadStats() => _statsLayoutView.SetStats(_model.GetStats());
    }
}