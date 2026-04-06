using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

namespace ExternalSource
{
    [CreateAssetMenu(fileName = "StatsDataSource", menuName = "Scriptable Objects/DataSources/StatsDataSource")]
    public class StatsDataSource : ScriptableObject
    {
        [SerializeField] private List<Stat> stats = new();
        
        public event Action<List<Stat>> OnChange;
        
        [ContextMenu("Apply Changes In Runtime")]
        public void ApplyChanges()
        {
            if (Application.isPlaying) OnChange?.Invoke(stats);
        }
        
        public List<Stat> GetStats() => stats.ToList();
    }
}