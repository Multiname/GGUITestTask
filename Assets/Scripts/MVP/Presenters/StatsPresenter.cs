using Entities;
using MVP.Models;
using MVP.Views.Content.Stats;
using Zenject;

namespace MVP.Presenters
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
        
        protected override void LoadList() => _statsLayoutView.SetStats(Model.GetList());
    }
}