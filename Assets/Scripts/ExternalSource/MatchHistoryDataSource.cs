using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

namespace ExternalSource
{
    [CreateAssetMenu(fileName = "MatchHistoryDataSource", menuName = "Scriptable Objects/DataSources/MatchHistoryDataSource")]
    public class MatchHistoryDataSource : ScriptableObject
    {
        [SerializeField] private List<Match> matches = new();
        
        public event Action<List<Match>> OnChange;
        
        [ContextMenu("Apply Changes In Runtime")]
        public void ApplyChanges()
        {
            if (Application.isPlaying) OnChange?.Invoke(matches);
        }
        
        public List<Match> GetMatches() => matches.ToList();
    }
}
