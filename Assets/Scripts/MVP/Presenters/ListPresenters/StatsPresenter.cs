using Entities;
using MVP.Models.ListModels;
using MVP.Views.Content.Stats;
using Zenject;

namespace MVP.Presenters.ListPresenters
{
    public class StatsPresenter : ListPresenterBase<Stat>
    {
        private readonly StatsLayoutView _statsLayoutView;

        [Inject]
        public StatsPresenter(
            StatsModel model,
            StatsLayoutView statsLayoutView
        ) : base(model)
        {
            _statsLayoutView = statsLayoutView;
        }

        public override void Initialize()
        {
            base.Initialize();

            _statsLayoutView.OnStatPointsChanged += ((StatsModel)Model).UpdateStatPoints;
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _statsLayoutView.OnStatPointsChanged -= ((StatsModel)Model).UpdateStatPoints;
        }
        
        protected override void LoadList() => _statsLayoutView.SetStats(Model.GetList());
    }
}