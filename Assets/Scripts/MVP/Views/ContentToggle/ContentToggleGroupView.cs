using System;
using UnityEngine;

namespace MVP.Views.ContentToggle
{
    public class ContentToggleGroupView : MonoBehaviour
    {
        [SerializeField] private ContentToggleView overviewToggle;
        [SerializeField] private ContentToggleView achievementsToggle;
        
        public event Action OnOverviewClick;
        public event Action OnAchievementsClick;

        public void Start()
        {
            overviewToggle.SetSelected(true);
        }

        public void OnEnable()
        {
            overviewToggle.OnClick += HandleOverviewToggleClick;
            achievementsToggle.OnClick += HandleAchievementsToggleClick;
        }

        private void OnDisable()
        {
            overviewToggle.OnClick -= HandleOverviewToggleClick;
            achievementsToggle.OnClick -= HandleAchievementsToggleClick;
        }

        private void HandleOverviewToggleClick()
        {
            overviewToggle.SetSelected(true);
            achievementsToggle.SetSelected(false);
            
            OnOverviewClick?.Invoke();
        }
        
        private void HandleAchievementsToggleClick()
        {
            achievementsToggle.SetSelected(true);
            overviewToggle.SetSelected(false);
            
            OnAchievementsClick?.Invoke();
        }
    }
}
