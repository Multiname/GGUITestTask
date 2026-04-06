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

        public void SetStats(List<Stat> stats)
        {
            Clear();
            
            foreach (var stat in stats)
            {
                var statView = _statViewFactory.Create();
                statView.transform.SetParent(transform);
                statView.SetHeader(stat.header);
                statView.SetSubheader(stat.subheader);
                statView.SetPoints(stat.points);
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