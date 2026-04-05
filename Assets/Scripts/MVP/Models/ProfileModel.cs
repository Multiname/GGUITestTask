using System;
using Zenject;

namespace MVP.Models
{
    public class ProfileModel
    {
        private int _avatarId;
        public event Action<int> OnChangeAvatarId;
        public int GetAvatarId() => _avatarId;
        public void SetAvatarId(int id) => SetValue(ref _avatarId, id, ref OnChangeAvatarId);
        
        private string _nickname;
        public event Action<string> OnChangeNickname;
        public string GetNickname() => _nickname;
        public void SetNickname(string nickname) => SetValue(ref _nickname, nickname, ref OnChangeNickname);
        
        private int _level;
        public event Action<int> OnChangeLevel;
        public int GetLevel() => _level;
        public void SetLevel(int level) => SetValue(ref _level, level, ref OnChangeLevel);
        
        private int _currentProgress;
        public event Action<int> OnChangeCurrentProgress;
        public int GetCurrentProgress() => _currentProgress;
        public void SetCurrentProgress(int progress) => SetValue(ref _currentProgress, progress, ref OnChangeCurrentProgress);
        
        private int _targetProgress;
        public event Action<int> OnChangeTargetProgress;
        public int GetTargetProgress() => _targetProgress;
        public void SetTargetProgress(int progress) => SetValue(ref _targetProgress, progress, ref OnChangeTargetProgress);
        
        [Inject]
        public ProfileModel()
        {
            _avatarId = 0;
            _nickname = "NICKNAME";
            _level = 1;
            _currentProgress = 42;
            _targetProgress = 100;
        }

        private static void SetValue<T>(ref T field, T value, ref Action<T> onChangeEvent)
        {
            if (field.Equals(value)) return;
            field = value;
            onChangeEvent?.Invoke(value);
        }
    }
}