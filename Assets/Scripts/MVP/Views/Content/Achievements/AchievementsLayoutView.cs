using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace MVP.Views.Content.Achievements
{
    public class AchievementsLayoutView: MonoBehaviour
    {
        [Inject] private AchievementsRowView.Factory _achievementsRowViewFactory;
        
        private readonly List<AchievementsRowView>  _achievementsRowsViews = new();

        public void SetAchievements(List<Achievement> achievements)
        {
            Clear();

            AchievementsRowView currentRow = null;
            for (var i = 0; i < achievements.Count; ++i)
            {
                if (i % AchievementsRowView.MaxNumberOfAchievements == 0)
                {
                    currentRow = _achievementsRowViewFactory.Create();
                    currentRow.transform.SetParent(transform);
                    _achievementsRowsViews.Add(currentRow);
                }
                
                currentRow?.AddAchievement(achievements[i]);
            }
        }
        
        private void Clear()
        {
            foreach (var achievementsRow in _achievementsRowsViews)
            {
                achievementsRow.Clear();
                Destroy(achievementsRow.gameObject);
            }
            _achievementsRowsViews.Clear();
        }
    }
}