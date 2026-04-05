using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace MVP.Views.Content.Achievements
{
    public class AchievementsRowView : MonoBehaviour
    {
        public const int MaxNumberOfAchievements = 3;

        [Inject] private AchievementView.Factory _achievementViewFactory;
        
        private readonly List<AchievementView> _achievements = new();

        public void AddAchievement(Achievement achievementData)
        {
            if (_achievements.Count >= MaxNumberOfAchievements) return;

            var achievement = _achievementViewFactory.Create();
            achievement.transform.SetParent(transform);
            achievement.SetIcon(achievementData.Icon);
            achievement.SetHeader(achievementData.Header);
            achievement.SetDate(achievementData.Date);
            _achievements.Add(achievement);
        }

        public void Clear()
        {
            foreach (var achievement in _achievements)
            {
                Destroy(achievement.gameObject);
            }
            _achievements.Clear();
        }
        
        public class Factory :  PlaceholderFactory<AchievementsRowView> { }
    }
}