using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services
{
    public abstract class SpriteServiceBase
    {
        private readonly Dictionary<string, Sprite> _sprites = new();

        public async UniTask<Sprite> GetSprite(int id)
        {
            var key = FormKeyFromId(id);
            if (_sprites.TryGetValue(key, out var sprite))
            {
                return sprite;
            }

            if (!await LoadSprite(id)) return null;

            return _sprites[key];
        }

        private async UniTask<bool> LoadSprite(int id)
        {
            var key = FormKeyFromId(id);
            
            var checkHandle = Addressables.LoadResourceLocationsAsync(key);
            await checkHandle.ToUniTask();

            var assetFound = checkHandle.Status == AsyncOperationStatus.Succeeded && checkHandle.Result.Count > 0;
            
            if (checkHandle.IsValid()) Addressables.Release(checkHandle);

            if (!assetFound) return false;
            
            var handle = Addressables.LoadAssetAsync<Texture2D>(key);
            await handle.ToUniTask();
            
            var texture = handle.Result;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            _sprites.Add(key, sprite);
            
            if (handle.IsValid()) Addressables.Release(handle);
            
            return true;
        }

        protected abstract string FormKeyFromId(int id);
    }
}