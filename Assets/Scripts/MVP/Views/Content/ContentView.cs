using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views.Content
{
    public class ContentView : MonoBehaviour
    {
        private const string OverviewContentHeader = "OVERVIEW";
        private const string AchievementsContentHeader = "ACHIEVEMENTS";
        
        [SerializeField] private TextMeshProUGUI contentHeader;

        [SerializeField] private GameObject overviewLayout;
        [SerializeField] private GameObject achievementsLayout;
        
        [SerializeField] private Scrollbar scrollbar;

        public void ShowOverview()
        {
            contentHeader.text = OverviewContentHeader;
            
            overviewLayout.SetActive(true);
            achievementsLayout.SetActive(false);
            
            ResetScroll();
        }
        
        public void ShowAchievements()
        {
            contentHeader.text = AchievementsContentHeader;
            
            achievementsLayout.SetActive(true);
            overviewLayout.SetActive(false);
            
            ResetScroll();
        }

        private void ResetScroll() => scrollbar.value = 1;
    }
}
