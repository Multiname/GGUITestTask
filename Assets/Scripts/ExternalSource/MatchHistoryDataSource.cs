using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

namespace ExternalSource
{
    [CreateAssetMenu(fileName = "MatchHistoryDataSource", menuName = "Scriptable Objects/DataSources/MatchHistoryDataSource")]
    public class MatchHistoryDataSource : ListDataSourceBase<Match>
    {
        [SerializeField] private List<Match> matches = new();

        [ContextMenu("Apply Changes In Runtime")]
        public override void ApplyChanges() => base.ApplyChanges();

        public override List<Match> GetList() => matches.ToList();
    }
}
