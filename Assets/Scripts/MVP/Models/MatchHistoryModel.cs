using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Zenject;

namespace MVP.Models
{
    public class MatchHistoryModel
    {
        private readonly List<Match> _matches;

        public event Action OnMatchesChanged;

        [Inject]
        private MatchHistoryModel()
        {
            var match = new Match()
            {
                Header = "UNRANKED",
                Details = "BATTLE"
            };

            _matches = new List<Match>
            {
                new()
                {
                    Header = "UNRANKED",
                    Details = "BATTLE 1"
                },
                new()
                {
                    Header = "UNRANKED",
                    Details = "BATTLE 2"
                },
                new()
                {
                    Header = "UNRANKED",
                    Details = "BATTLE 3"
                },
                new()
                {
                    Header = "UNRANKED",
                    Details = "BATTLE 4"
                },
                new()
                {
                    Header = "UNRANKED",
                    Details = "BATTLE 5"
                },
            };
        }

        public List<Match> GetRecentMatches(int limit) => _matches.TakeLast(limit).Reverse().ToList();

        public void AddMatch(Match match)
        {
            _matches.Add(match);
            OnMatchesChanged?.Invoke();
        }
    }
}