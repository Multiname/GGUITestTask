using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

namespace ExternalSource
{
    [CreateAssetMenu(fileName = "StatsDataSource", menuName = "Scriptable Objects/DataSources/StatsDataSource")]
    public class StatsDataSource : ListDataSourceBase<Stat>
    {
        [SerializeField] private List<Stat> stats = new();

        [ContextMenu("Apply Changes In Runtime")]
        public override void ApplyChanges() => base.ApplyChanges();

        public override List<Stat> GetList() => stats.ToList();
    }
}