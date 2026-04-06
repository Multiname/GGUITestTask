using ExternalSource;
using MVP.Models;
using MVP.Presenters;
using MVP.Views.Content;
using MVP.Views.Content.Achievements;
using MVP.Views.Content.Matches;
using MVP.Views.Content.Stats;
using MVP.Views.ContentToggle;
using MVP.Views.Profile;
using UnityEngine;
using Zenject;

namespace Services
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Views")]
        [SerializeField] private PlayerAvatarView playerAvatarView;
        [SerializeField] private PlayerNicknameView playerNicknameView;
        [SerializeField] private PlayerProgressView playerProgressView;
        
        [SerializeField] private ContentToggleGroupView contentToggleGroupView;
        [SerializeField] private ContentView contentView;
        
        [SerializeField] private MatchLayoutView matchLayoutView;
        [SerializeField] private StatsLayoutView statsLayoutView;
        [SerializeField] private AchievementsLayoutView achievementsLayoutView;
        
        [Header("Services")]
        [SerializeField] private FontService fontService;

        [Header("Prefabs")]
        [SerializeField] private MatchView matchViewPrefab;
        [SerializeField] private StatView statViewPrefab;
        [SerializeField] private AchievementView achievementViewPrefab;
        [SerializeField] private AchievementsRowView achievementsRowViewPrefab;
        
        [Header("ExternalSources")]
        [SerializeField] private ProfileDataSource profileDataSource;
        [SerializeField] private MatchHistoryDataSource matchHistoryDataSource;
        [SerializeField] private StatsDataSource statsDataSource;
        
        public override void InstallBindings()
        {
            // Services
            Container.Bind<AvatarService>().AsSingle();
            Container.Bind<FontService>().FromInstance(fontService).AsSingle();
            Container.Bind<AchievementIconService>().AsSingle();
            
            // ExternalSources
            Container.BindInterfacesAndSelfTo<ProfileDataSource>().FromInstance(profileDataSource).AsSingle();
            Container.Bind<MatchHistoryDataSource>().FromInstance(matchHistoryDataSource).AsSingle();
            Container.Bind<StatsDataSource>().FromInstance(statsDataSource).AsSingle();
            
            // Prefabs
            Container.BindFactory<MatchView, MatchView.Factory>().FromComponentInNewPrefab(matchViewPrefab);
            Container.BindFactory<StatView, StatView.Factory>().FromComponentInNewPrefab(statViewPrefab);
            Container.BindFactory<AchievementView, AchievementView.Factory>().FromComponentInNewPrefab(achievementViewPrefab);
            Container.BindFactory<AchievementsRowView, AchievementsRowView.Factory>().FromComponentInNewPrefab(achievementsRowViewPrefab);
            
            // Models
            Container.BindInterfacesAndSelfTo<ProfileModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<MatchHistoryModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<StatsModel>().AsSingle();
            Container.Bind<AchievementsModel>().AsSingle();
            
            // Views
            Container.Bind<PlayerAvatarView>().FromInstance(playerAvatarView).AsSingle();
            Container.Bind<PlayerNicknameView>().FromInstance(playerNicknameView).AsSingle();
            Container.Bind<PlayerProgressView>().FromInstance(playerProgressView).AsSingle();
            
            Container.Bind<ContentToggleGroupView>().FromInstance(contentToggleGroupView).AsSingle();
            Container.Bind<ContentView>().FromInstance(contentView).AsSingle();
            
            Container.Bind<MatchLayoutView>().FromInstance(matchLayoutView).AsSingle();
            Container.Bind<StatsLayoutView>().FromInstance(statsLayoutView).AsSingle();
            Container.Bind<AchievementsLayoutView>().FromInstance(achievementsLayoutView).AsSingle();
            
            // Presenters
            Container.BindInterfacesAndSelfTo<ProfilePresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContentPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<MatchHistoryPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<StatsPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<AchievementsPresenter>().AsSingle();
        }
    }
}
