using System;
using MVP.Views.Content;
using MVP.Views.Content.Stats;
using MVP.Views.ContentToggle;
using Zenject;

namespace MVP.Presenters
{
    public class ContentPresenter : IDisposable, IInitializable
    {
        private readonly ContentView _contentView;
        private readonly ContentToggleGroupView _contentToggleGroupView;
        private readonly SaveStatsButtonView _saveStatsButtonView;

        [Inject]
        public ContentPresenter(
            ContentView contentView,
            ContentToggleGroupView contentToggleGroupView,
            SaveStatsButtonView saveStatsButtonView
        )
        {
            _contentView = contentView;
            _contentToggleGroupView = contentToggleGroupView;
            _saveStatsButtonView = saveStatsButtonView;
        }

        public void Initialize()
        {
            _contentToggleGroupView.OnOverviewClick += HandleOverviewClick;
            _contentToggleGroupView.OnAchievementsClick += HandleAchievementsClick;
        }

        public void Dispose()
        {
            _contentToggleGroupView.OnOverviewClick -= HandleOverviewClick;
            _contentToggleGroupView.OnAchievementsClick -= HandleAchievementsClick;
        }

        private void HandleOverviewClick()
        {
            _contentView.ShowOverview();
            _saveStatsButtonView.gameObject.SetActive(true);
        }
        
        private void HandleAchievementsClick()
        {
            _contentView.ShowAchievements();
            _saveStatsButtonView.gameObject.SetActive(false);
        }
    }
}