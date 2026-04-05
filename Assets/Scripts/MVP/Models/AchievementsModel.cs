using System;
using System.Collections.Generic;
using Entities;
using Zenject;

namespace MVP.Models
{
    public class AchievementsModel
    {
        private readonly List<Achievement> _achievements;

        public event Action OnAchievementsChanged;

        [Inject]
        private AchievementsModel()
        {
            _achievements = new List<Achievement>
            {
                new()
                {
                    IconId = 0,
                    Header = "EMPIRE WILL RISE",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 1,
                    Header = "MASTERY",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 2,
                    Header = "BLOOD MASTER",
                    Date = new DateTime(2021, 11, 20),
                },
                
                new()
                {
                    IconId = 0,
                    Header = "EMPIRE WILL RISE",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 1,
                    Header = "MASTERY",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 2,
                    Header = "BLOOD MASTER",
                    Date = new DateTime(2021, 11, 20),
                },
                
                new()
                {
                    IconId = 0,
                    Header = "EMPIRE WILL RISE",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 1,
                    Header = "MASTERY",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 2,
                    Header = "BLOOD MASTER",
                    Date = new DateTime(2021, 11, 20),
                },
                
                new()
                {
                    IconId = 0,
                    Header = "EMPIRE WILL RISE",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 1,
                    Header = "MASTERY",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 2,
                    Header = "BLOOD MASTER",
                    Date = new DateTime(2021, 11, 20),
                },
                
                new()
                {
                    IconId = 0,
                    Header = "EMPIRE WILL RISE",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 1,
                    Header = "MASTERY",
                    Date = new DateTime(2021, 11, 20),
                },
                new()
                {
                    IconId = 2,
                    Header = "BLOOD MASTER",
                    Date = new DateTime(2021, 11, 20),
                },
            };
        }

        public List<Achievement> GetAchievements() => _achievements;

        public void AddAchievement(Achievement achievement)
        {
            _achievements.Add(achievement);
            OnAchievementsChanged?.Invoke();
        }
    }
}