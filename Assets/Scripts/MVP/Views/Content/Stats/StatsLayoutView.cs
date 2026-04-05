using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace MVP.Views.Content.Stats
{
    public class StatsLayoutView : MonoBehaviour
    {
        [Inject] private StatView _statViewPrefab;
        
        private readonly List<StatView>  _statViews = new();

        public void SetStats(List<Stat> stats)
        {
            Clear();
            
            foreach (var stat in stats)
            {
                var statView = Instantiate(_statViewPrefab, transform);
                statView.SetHeader(stat.Header);
                statView.SetSubheader(stat.Subheader);
                statView.SetPoints(stat.Points);
                _statViews.Add(statView);
            }
        }
        
        private void Clear()
        {
            foreach (var stat in _statViews)
            {
                Destroy(stat.gameObject);
            }
            _statViews.Clear();
        }
    }
}