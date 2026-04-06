using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services
{
    public class AchievementIconService : SpriteServiceBase
    {
        protected override string FormKeyFromId(int id) => $"achievement_icon_{id}";
    }
}