using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

namespace ExternalSource
{
    [CreateAssetMenu(fileName = "AchievementsDataSource", menuName = "Scriptable Objects/DataSources/AchievementsDataSource")]
    public class AchievementsDataSource : ListDataSourceBase<Achievement>
    {
        [SerializeField] private List<Achievement> achievements = new();

        [ContextMenu("Apply Changes In Runtime")]
        public override void ApplyChanges() => base.ApplyChanges();

        public override List<Achievement> GetList() => achievements.ToList();
    }
}