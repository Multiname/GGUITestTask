using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views.Profile
{
    public class PlayerProgressView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private Slider slider;

        public void SetLevel(int level) => levelText.text = $"LEVEL {level}:";

        public void SetProgress(int currentValue, int targetValue)
        {
            progressText.text = $"{currentValue}/{targetValue}";
            slider.value = (float)currentValue / targetValue;
        }
    }
}
