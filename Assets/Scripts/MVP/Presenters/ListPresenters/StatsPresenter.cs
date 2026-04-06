using Entities;
using MVP.Models.ListModels;
using MVP.Views.Content.Stats;
using Zenject;

namespace MVP.Presenters.ListPresenters
{
    public class StatsPresenter : ListPresenterBase<Stat>
    {
        private readonly StatsLayoutView _statsLayoutView;
        private readonly SaveStatsButtonView _saveStatsButtonView;

        [Inject]
        public StatsPresenter(
            StatsModel model,
            StatsLayoutView statsLayoutView,
            SaveStatsButtonView saveStatsButtonView
        ) : base(model)
        {
            _statsLayoutView = statsLayoutView;
            _saveStatsButtonView = saveStatsButtonView;
        }

        public override void Initialize()
        {
            base.Initialize();

            _statsLayoutView.OnStatPointsChanged += HandleStatPointsChanged;
            _saveStatsButtonView.OnClick += HandleSaveStatsButtonViewClick;
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _statsLayoutView.OnStatPointsChanged -= HandleStatPointsChanged;
            _saveStatsButtonView.OnClick -= HandleSaveStatsButtonViewClick;
        }
        
        protected override void LoadList() => _statsLayoutView.SetStats(Model.GetList());
        
        private void HandleStatPointsChanged() => _saveStatsButtonView.SetActive(true);

        private void HandleSaveStatsButtonViewClick()
        {
            var editedPoints = _statsLayoutView.EditedPoints;
            ((StatsModel)Model).UpdateStatPoints(editedPoints);
            
            _statsLayoutView.ConfirmEdit();
            _saveStatsButtonView.SetActive(false);
        }
    }
}