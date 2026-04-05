using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using UnityEngine;
using Zenject;

namespace Services
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerAvatarView playerAvatarView;
        [SerializeField] private PlayerNicknameView playerNicknameView;
        [SerializeField] private PlayerProgressView playerProgressView;
        
        public override void InstallBindings()
        {
            Container.Bind<AvatarService>().AsSingle();
            
            Container.Bind<ProfileModel>().AsSingle();
            
            Container.Bind<PlayerAvatarView>().FromInstance(playerAvatarView).AsSingle();
            Container.Bind<PlayerNicknameView>().FromInstance(playerNicknameView).AsSingle();
            Container.Bind<PlayerProgressView>().FromInstance(playerProgressView).AsSingle();

            Container.BindInterfacesAndSelfTo<ProfilePresenter>().AsSingle();
        }
    }
}
