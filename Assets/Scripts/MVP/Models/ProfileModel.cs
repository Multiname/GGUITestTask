using System;
using ExternalSource;
using Zenject;

namespace MVP.Models
{
    public class ProfileModel : IDisposable, IInitializable
    {
        private readonly ProfileDataSource _dataSource;
        
        private int _avatarId;
        public event Action<int> OnChangeAvatarId;
        public int GetAvatarId() => _avatarId;
        private void SetAvatarId(int id) => SetValue(ref _avatarId, id, ref OnChangeAvatarId);
        
        private string _nickname;
        public event Action<string> OnChangeNickname;
        public string GetNickname() => _nickname;
        private void SetNickname(string nickname) => SetValue(ref _nickname, nickname, ref OnChangeNickname);
        
        private int _level;
        public event Action<int> OnChangeLevel;
        public int GetLevel() => _level;
        private void SetLevel(int level) => SetValue(ref _level, level, ref OnChangeLevel);
        
        private int _currentProgress;
        public event Action<int> OnChangeCurrentProgress;
        public int GetCurrentProgress() => _currentProgress;
        private void SetCurrentProgress(int progress) => SetValue(ref _currentProgress, progress, ref OnChangeCurrentProgress);
        
        private int _targetProgress;
        public event Action<int> OnChangeTargetProgress;
        public int GetTargetProgress() => _targetProgress;
        private void SetTargetProgress(int progress) => SetValue(ref _targetProgress, progress, ref OnChangeTargetProgress);
        
        [Inject]
        public ProfileModel(ProfileDataSource profileDataSource)
        {
            _dataSource = profileDataSource;
        }

        public void Initialize()
        {
            _avatarId = _dataSource.GetAvatarId();
            _nickname = _dataSource.GetNickname();
            _level = _dataSource.GetLevel();
            _currentProgress = _dataSource.GetCurrentProgress();
            _targetProgress = _dataSource.GetTargetProgress();

            _dataSource.OnAvatarIdChange += SetAvatarId;
            _dataSource.OnNicknameChange += SetNickname;
            _dataSource.OnLevelChange += SetLevel;
            _dataSource.OnCurrentProgressChange += SetCurrentProgress;
            _dataSource.OnTargetProgressChange += SetTargetProgress;
        }

        public void Dispose()
        {
            _dataSource.OnAvatarIdChange -= SetAvatarId;
            _dataSource.OnNicknameChange -= SetNickname;
            _dataSource.OnLevelChange -= SetLevel;
            _dataSource.OnCurrentProgressChange -= SetCurrentProgress;
            _dataSource.OnTargetProgressChange -= SetTargetProgress;
        }

        private static void SetValue<T>(ref T field, T value, ref Action<T> onChangeEvent)
        {
            if (field.Equals(value)) return;
            field = value;
            onChangeEvent?.Invoke(value);
        }
    }
}