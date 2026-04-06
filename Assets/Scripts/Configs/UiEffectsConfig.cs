using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "UiEffectsConfig", menuName = "Scriptable Objects/Configs/UiEffectsConfig")]
    public class UiEffectsConfig : ScriptableObject
    {
        [field: SerializeField] public float ToggleSelectTransitionDuration { get; private set; } = 1.0f;
        [field: SerializeField] public float ToggleHoverMaxAlpha { get; private set; } = 0.5f;
        [field: SerializeField] public float ToggleHoverFlickerDuration { get; private set; } = 1.0f;
        [field: SerializeField] public float ContentTransitionDuration { get; private set; } = 1.0f;
    }
}
