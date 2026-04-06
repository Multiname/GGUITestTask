using Entities;
using MVP.Models.ListModels;
using MVP.Views.Content.Matches;
using Zenject;

namespace MVP.Presenters.ListPresenters
{
    public class MatchHistoryPresenter : ListPresenterBase<Match>
    {
        private readonly MatchLayoutView _matchLayoutView;

        [Inject]
        public MatchHistoryPresenter(
            MatchHistoryModel model,
            MatchLayoutView matchLayoutView
        ) : base(model)
        {
            _matchLayoutView = matchLayoutView;
        }
        
        protected override void LoadList() => _matchLayoutView.SetRecentMatches((Model as MatchHistoryModel)?.GetRecentMatches(MatchLayoutView.MaxNumberOfMatches));
    }
}