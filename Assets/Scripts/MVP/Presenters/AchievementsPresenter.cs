using System;
using Cysharp.Threading.Tasks;
using Entities;
using MVP.Models;
using MVP.Views.Content.Achievements;
using Services;
using Zenject;

namespace MVP.Presenters
{
    public class AchievementsPresenter : IDisposable, IInitializable
    {
        private readonly AchievementsModel _model;
        private readonly AchievementsLayoutView _achievementsLayoutView;
        
        private readonly AchievementIconService _achievementIconService;

        [Inject]
        public AchievementsPresenter(
            AchievementsModel model,
            AchievementsLayoutView achievementsLayoutView,
            AchievementIconService achievementIconService
        )
        {
            _model = model;
            _achievementsLayoutView = achievementsLayoutView;
            _achievementIconService = achievementIconService;
        }

        public void Initialize()
        {
            LoadAchievements();
            _model.OnAchievementsChanged += LoadAchievements;
        }

        public void Dispose()
        {
            _model.OnAchievementsChanged -= LoadAchievements;
        }

        private void LoadAchievements() => LoadAchievementsAsync().Forget();

        private async UniTask LoadAchievementsAsync()
        {
            var achievements = _model.GetAchievements();

            foreach (var achievement in achievements)
            {
                await LoadAchievementIconsAsync(achievement);
            }
            
            _achievementsLayoutView.SetAchievements(achievements);
        }

        private async UniTask LoadAchievementIconsAsync(Achievement achievement)
        {
            if (achievement.Icon != null) return;
            achievement.Icon = await _achievementIconService.GetIcon(achievement.IconId);
        }
    }
}