using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using ExternalSource;
using Zenject;

namespace MVP.Models
{
    public class MatchHistoryModel : IDisposable, IInitializable
    {
        private readonly MatchHistoryDataSource _dataSource;
        
        private List<Match> _matches;

        public event Action OnMatchesChanged;

        public List<Match> GetRecentMatches(int limit) => _matches.TakeLast(limit).Reverse().ToList();

        [Inject]
        public MatchHistoryModel(MatchHistoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        
        public void Initialize()
        {
            _matches = _dataSource.GetMatches();
            _dataSource.OnChange += SetMatches;
        }
        
        public void Dispose()
        {
            _dataSource.OnChange -= SetMatches;
        }

        private void SetMatches(List<Match> matches)
        {
            _matches = matches;
            OnMatchesChanged?.Invoke();
        }
    }
}