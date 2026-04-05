using MVP.Models;
using MVP.Presenters;
using MVP.Views.Content;
using MVP.Views.Content.Matches;
using MVP.Views.ContentToggle;
using MVP.Views.Profile;
using UnityEngine;
using Zenject;

namespace Services
{
    public class GameInstaller : MonoInstaller
    {
        // Views
        [SerializeField] private PlayerAvatarView playerAvatarView;
        [SerializeField] private PlayerNicknameView playerNicknameView;
        [SerializeField] private PlayerProgressView playerProgressView;
        
        [SerializeField] private ContentToggleGroupView contentToggleGroupView;
        [SerializeField] private ContentView contentView;
        
        [SerializeField] private MatchLayoutView matchLayoutView;
        
        // Services
        [SerializeField] private FontService fontService;

        // Prefabs
        [SerializeField] private MatchView matchViewPrefab;
        
        public override void InstallBindings()
        {
            // Services
            Container.Bind<AvatarService>().AsSingle();
            Container.Bind<FontService>().FromInstance(fontService).AsSingle();
            
            // Prefabs
            Container.Bind<MatchView>().FromInstance(matchViewPrefab).AsTransient();
            
            // Models
            Container.Bind<ProfileModel>().AsSingle();
            Container.Bind<MatchHistoryModel>().AsSingle();
            
            // Views
            Container.Bind<PlayerAvatarView>().FromInstance(playerAvatarView).AsSingle();
            Container.Bind<PlayerNicknameView>().FromInstance(playerNicknameView).AsSingle();
            Container.Bind<PlayerProgressView>().FromInstance(playerProgressView).AsSingle();
            
            Container.Bind<ContentToggleGroupView>().FromInstance(contentToggleGroupView).AsSingle();
            Container.Bind<ContentView>().FromInstance(contentView).AsSingle();
            
            Container.Bind<MatchLayoutView>().FromInstance(matchLayoutView).AsSingle();
            
            // Presenters
            Container.BindInterfacesAndSelfTo<ProfilePresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContentPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<MatchHistoryPresenter>().AsSingle();
        }
    }
}
