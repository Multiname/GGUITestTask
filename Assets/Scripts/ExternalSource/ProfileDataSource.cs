using System;
using UnityEngine;
using Zenject;

namespace ExternalSource
{
    [CreateAssetMenu(fileName = "ProfileDataSource", menuName = "Scriptable Objects/ProfileDataSource")]
    public class ProfileDataSource : ScriptableObject, IInitializable
    {
        [SerializeField] private int avatarId;
        [SerializeField] private string nickname;
        [SerializeField] private int level;
        [SerializeField] private int currentProgress;
        [SerializeField] private int targetProgress;

        private int _cachedAvatarId;
        private string _cachedNickname;
        private int _cachedLevel;
        private int _cachedCurrentProgress;
        private int _cachedTargetProgress;

        public event Action<int> OnAvatarIdChange;
        public event Action<string> OnNicknameChange;
        public event Action<int> OnLevelChange;
        public event Action<int> OnCurrentProgressChange;
        public event Action<int> OnTargetProgressChange;
        
        public void Initialize()
        {
            _cachedAvatarId = avatarId;
            _cachedNickname = nickname;
            _cachedLevel = level;
            _cachedCurrentProgress = currentProgress;
            _cachedTargetProgress = targetProgress;
        }

        private void OnValidate()
        {
            if (!Application.isPlaying) return;

            CheckChanges(ref _cachedAvatarId, avatarId, ref OnAvatarIdChange);
            CheckChanges(ref _cachedNickname, nickname, ref OnNicknameChange);
            CheckChanges(ref _cachedLevel, level, ref OnLevelChange);
            CheckChanges(ref _cachedCurrentProgress, currentProgress, ref OnCurrentProgressChange);
            CheckChanges(ref _cachedTargetProgress, targetProgress, ref OnTargetProgressChange);
        }

        private static void CheckChanges<T>(ref T cachedValue, T currentValue, ref Action<T> onChangeEvent)
        {
            if (cachedValue.Equals(currentValue)) return;
            cachedValue = currentValue;
            onChangeEvent?.Invoke(cachedValue);
        }
        
        public int GetAvatarId() => _cachedAvatarId;
        public string GetNickname() => _cachedNickname;
        public int GetLevel() => _cachedLevel;
        public int GetCurrentProgress() => _cachedCurrentProgress;
        public int GetTargetProgress() => _cachedTargetProgress;
    }
}
