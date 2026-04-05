using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services
{
    public class AchievementIconService
    {
        private readonly Dictionary<string, Sprite> _icons = new();

        public async UniTask<Sprite> GetIcon(int id)
        {
            var key = FormKeyFromId(id);
            if (_icons.TryGetValue(key, out var icon))
            {
                return icon;
            }

            if (!await LoadIcon(id)) return null;

            return _icons[key];
        }

        private async UniTask<bool> LoadIcon(int id)
        {
            var key = FormKeyFromId(id);
            var handle = Addressables.LoadAssetAsync<Texture2D>(key);
            await handle.ToUniTask();
            
            if (handle.Result == null) return false;
            
            var icon = handle.Result;
            var sprite = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), new Vector2(0.5f, 0.5f));
            _icons.Add(key, sprite);
            
            return true;
        }
        
        private static string FormKeyFromId(int id) => $"achievement_icon_{id}";
    }
}