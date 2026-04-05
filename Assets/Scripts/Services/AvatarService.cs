using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services
{
    public class AvatarService
    {
        private readonly Dictionary<string, Sprite> _avatars = new();

        public async UniTask<Sprite> GetAvatar(int id)
        {
            var key = FormKeyFromId(id);
            if (_avatars.TryGetValue(key, out var avatar))
            {
                return avatar;
            }

            if (!await LoadAvatar(id)) return null;

            return _avatars[key];
        }

        private async UniTask<bool> LoadAvatar(int id)
        {
            var key = FormKeyFromId(id);
            var handle = Addressables.LoadAssetAsync<Texture2D>(key);
            await handle.ToUniTask();
            
            if (handle.Result == null) return false;
            
            var avatar = handle.Result;
            var sprite = Sprite.Create(avatar, new Rect(0, 0, avatar.width, avatar.height), new Vector2(0.5f, 0.5f));
            _avatars.Add(key, sprite);
            
            return true;
        }
        
        private static string FormKeyFromId(int id) => $"avatar_{id}";
    }
}