using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services
{
    public class AvatarService : SpriteServiceBase
    {
        protected override string FormKeyFromId(int id) => $"avatar_{id}";
    }
}