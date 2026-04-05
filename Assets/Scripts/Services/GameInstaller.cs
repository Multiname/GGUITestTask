using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using MVP.Views.ContentToggle;
using MVP.Views.Profile;
using UnityEngine;
using Zenject;

namespace Services
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerAvatarView playerAvatarView;
        [SerializeField] private PlayerNicknameView playerNicknameView;
        [SerializeField] private PlayerProgressView playerProgressView;
        
        [SerializeField] private ContentToggleGroupView contentToggleGroupView;
        [SerializeField] private ContentView contentView;
        
        [SerializeField] private FontService fontService;
        
        public override void InstallBindings()
        {
            Container.Bind<AvatarService>().AsSingle();
            Container.Bind<FontService>().FromInstance(fontService).AsSingle();
            
            Container.Bind<ProfileModel>().AsSingle();
            
            Container.Bind<PlayerAvatarView>().FromInstance(playerAvatarView).AsSingle();
            Container.Bind<PlayerNicknameView>().FromInstance(playerNicknameView).AsSingle();
            Container.Bind<PlayerProgressView>().FromInstance(playerProgressView).AsSingle();
            
            Container.Bind<ContentToggleGroupView>().FromInstance(contentToggleGroupView).AsSingle();
            Container.Bind<ContentView>().FromInstance(contentView).AsSingle();

            Container.BindInterfacesAndSelfTo<ProfilePresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContentPresenter>().AsSingle();
        }
    }
}
