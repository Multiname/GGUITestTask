using System;
using MVP.Models;
using MVP.Views.Content.Matches;
using Zenject;

namespace MVP.Presenters
{
    public class MatchHistoryPresenter : IDisposable, IInitializable
    {
        private readonly MatchHistoryModel _model;
        private readonly MatchLayoutView _matchLayoutView;

        [Inject]
        public MatchHistoryPresenter(
            MatchHistoryModel model,
            MatchLayoutView matchLayoutView
        )
        {
            _model = model;
            _matchLayoutView = matchLayoutView;
        }

        public void Initialize()
        {
            LoadMatches();
            _model.OnMatchesChanged += LoadMatches;
        }

        public void Dispose()
        {
            _model.OnMatchesChanged -= LoadMatches;
        }
        
        private void LoadMatches() => _matchLayoutView.SetRecentMatches(_model.GetRecentMatches(MatchLayoutView.MaxNumberOfMatches));
    }
}