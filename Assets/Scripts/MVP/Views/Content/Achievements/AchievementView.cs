using Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVP.Views.Content.Achievements
{
    public class AchievementView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private TextMeshProUGUI dateText;
        
        public void SetIcon(Sprite sprite) => icon.sprite = sprite;
        
        public void SetHeader(string text) => header.text = text.ToUpper();
        
        public void SetDate(Achievement.Date date) => dateText.text = $"{date.day}/{date.month}/{date.year}";
        
        public class Factory : PlaceholderFactory<AchievementView> {}
    }
}