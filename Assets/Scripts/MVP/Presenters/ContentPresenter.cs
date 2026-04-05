using System;
using MVP.Views.Content;
using MVP.Views.ContentToggle;
using Zenject;

namespace MVP.Presenters
{
    public class ContentPresenter : IDisposable, IInitializable
    {
        private readonly ContentView _contentView;
        private readonly ContentToggleGroupView _contentToggleGroupView;

        [Inject]
        public ContentPresenter(
            ContentView contentView,
            ContentToggleGroupView contentToggleGroupView
        )
        {
            _contentView = contentView;
            _contentToggleGroupView = contentToggleGroupView;
        }

        public void Initialize()
        {
            _contentToggleGroupView.OnOverviewClick += _contentView.ShowOverview;
            _contentToggleGroupView.OnAchievementsClick += _contentView.ShowAchievements;
        }

        public void Dispose()
        {
            _contentToggleGroupView.OnOverviewClick -= _contentView.ShowOverview;
            _contentToggleGroupView.OnAchievementsClick -= _contentView.ShowAchievements;
        }
    }
}