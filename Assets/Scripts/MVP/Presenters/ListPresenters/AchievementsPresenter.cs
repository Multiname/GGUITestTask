using Cysharp.Threading.Tasks;
using Entities;
using MVP.Models.ListModels;
using MVP.Views.Content.Achievements;
using Services.SpriteServices;
using Zenject;

namespace MVP.Presenters.ListPresenters
{
    public class AchievementsPresenter : ListPresenterBase<Achievement>
    {
        private readonly AchievementsLayoutView _achievementsLayoutView;
        
        private readonly AchievementIconService _achievementIconService;

        [Inject]
        public AchievementsPresenter(
            AchievementsModel model,
            AchievementsLayoutView achievementsLayoutView,
            AchievementIconService achievementIconService
        ) : base(model)
        {
            _achievementsLayoutView = achievementsLayoutView;
            _achievementIconService = achievementIconService;
        }
        
        protected override void LoadList() => LoadAchievementsAsync().Forget();
        
        private async UniTask LoadAchievementsAsync()
        {
            var achievements = Model.GetList();
        
            foreach (var achievement in achievements)
            {
                await LoadAchievementIconsAsync(achievement);
            }
            
            _achievementsLayoutView.SetAchievements(achievements);
        }
        
        private async UniTask LoadAchievementIconsAsync(Achievement achievement)
        {
            achievement.Icon = await _achievementIconService.GetSprite(achievement.iconId);
        }
    }
}