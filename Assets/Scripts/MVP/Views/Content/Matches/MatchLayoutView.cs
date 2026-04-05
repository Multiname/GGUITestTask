using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace MVP.Views.Content.Matches
{
    public class MatchLayoutView : MonoBehaviour
    {
        public const int MaxNumberOfMatches = 3;

        [Inject] private MatchView _matchViewPrefab;
        
        private readonly List<MatchView> _matches = new();

        public void SetRecentMatches(List<Match> matches)
        {
            Clear();
            
            for (var i = 0; i < Mathf.Min(matches.Count, MaxNumberOfMatches); ++i)
            {
                var match = Instantiate(_matchViewPrefab, transform);
                match.SetHeader(matches[i].Header);
                match.SetDetails(matches[i].Details);
                _matches.Add(match);
            }
        }

        private void Clear()
        {
            foreach (var match in _matches)
            {
                Destroy(match.gameObject);
            }
            _matches.Clear();
        }
    }
}
