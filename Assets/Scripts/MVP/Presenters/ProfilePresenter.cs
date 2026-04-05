using System;
using Cysharp.Threading.Tasks;
using MVP.Models;
using MVP.Views;
using Services;
using Zenject;

namespace MVP.Presenters
{
    public class ProfilePresenter : IDisposable, IInitializable
    {
        private readonly ProfileModel _profileModel;
        
        private readonly PlayerAvatarView _playerAvatarView;
        private readonly PlayerNicknameView  _playerNicknameView;
        private readonly PlayerProgressView _playerProgressView;

        private readonly AvatarService _avatarService;

        [Inject]
        public ProfilePresenter(
            ProfileModel profileModel,
            PlayerAvatarView playerAvatarView,
            PlayerNicknameView playerNicknameView,
            PlayerProgressView playerProgressView,
            AvatarService avatarService)
        {
            _profileModel = profileModel;
            _playerAvatarView = playerAvatarView;
            _playerNicknameView = playerNicknameView;
            _playerProgressView = playerProgressView;
            _avatarService = avatarService;
        }
        
        public void Initialize()
        {
            SetAvatar(_profileModel.GetAvatarId());
            _profileModel.OnChangeAvatarId += SetAvatar;
            
            _playerNicknameView.SetNickname(_profileModel.GetNickname());
            _profileModel.OnChangeNickname += _playerNicknameView.SetNickname;
            
            _playerProgressView.SetLevel(_profileModel.GetLevel());
            _profileModel.OnChangeLevel += _playerProgressView.SetLevel;
            
            _playerProgressView.SetProgress(_profileModel.GetCurrentProgress(), _profileModel.GetTargetProgress());
            _profileModel.OnChangeCurrentProgress += SetCurrentProgress;
            _profileModel.OnChangeTargetProgress += SetTargetProgress;
        }

        public void Dispose()
        {
            _profileModel.OnChangeAvatarId -= SetAvatar;
            _profileModel.OnChangeNickname -= _playerNicknameView.SetNickname;
            _profileModel.OnChangeLevel -= _playerProgressView.SetLevel;
            _profileModel.OnChangeCurrentProgress -= SetCurrentProgress;
            _profileModel.OnChangeTargetProgress -= SetTargetProgress;
        }

        private void SetAvatar(int id) => SetAvatarAsync(id).Forget();

        private async UniTask SetAvatarAsync(int id)
        {
            var avatar = await _avatarService.GetAvatar(id);
            if (avatar == null) return;
            
            _playerAvatarView.SetAvatar(avatar);
        }

        private void SetCurrentProgress(int currentProgress) => _playerProgressView.SetProgress(currentProgress,  _profileModel.GetTargetProgress());
        private void SetTargetProgress(int targetProgress) => _playerProgressView.SetProgress(_profileModel.GetCurrentProgress(),  targetProgress);
    }
}
