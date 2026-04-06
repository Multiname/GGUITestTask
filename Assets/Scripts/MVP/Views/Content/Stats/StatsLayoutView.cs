using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace MVP.Views.Content.Stats
{
    public class StatsLayoutView : MonoBehaviour
    {
        [Inject] private StatView.Factory _statViewFactory;
        
        private readonly List<StatView>  _statViews = new();
        
        public event Action<int, long> OnStatPointsChanged;

        public void SetStats(List<Stat> stats)
        {
            Clear();
            
            for (var i = 0; i < stats.Count; ++i)
            {
                var statView = _statViewFactory.Create();
                statView.transform.SetParent(transform);
                
                statView.SetHeader(stats[i].header);
                statView.SetSubheader(stats[i].subheader);
                statView.SetPoints(stats[i].points);
                
                var index = i;
                statView.PointsChangedCallback = (points) => OnStatPointsChanged?.Invoke(index, points);
                
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