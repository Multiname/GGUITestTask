using TMPro;
using UnityEngine;

namespace Services
{
    [CreateAssetMenu(fileName = "FontService", menuName = "Scriptable Objects/FontService")]
    public class FontService : ScriptableObject
    {
        [field: SerializeField] public TMP_FontAsset Regular { get; private set; }
        [field: SerializeField] public TMP_FontAsset Bold { get; private set; }
        
        [field: SerializeField] public Color Bright { get; private set; }
        [field: SerializeField] public Color Grey { get; private set; }
        [field: SerializeField] public Color Dark { get; private set; }
        [field: SerializeField] public Color Red { get; private set; }
    }
}