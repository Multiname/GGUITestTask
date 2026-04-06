using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using ExternalSource;
using Zenject;

namespace MVP.Models
{
    public class StatsModel : IDisposable, IInitializable
    {
        private readonly StatsDataSource _dataSource;
        
        private List<Stat> _stats;

        public event Action OnStatsChanged;

        [Inject]
        private StatsModel(StatsDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        
        public void Initialize()
        {
            _stats = _dataSource.GetStats();
            _dataSource.OnChange += SetStats;
        }
        
        public void Dispose()
        {
            _dataSource.OnChange -= SetStats;
        }

        public List<Stat> GetStats() => _stats.ToList();
        
        private void SetStats(List<Stat> stats)
        {
            _stats = stats;
            OnStatsChanged?.Invoke();
        }
    }
}