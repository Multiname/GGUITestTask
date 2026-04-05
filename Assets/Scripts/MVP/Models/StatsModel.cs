using System;
using System.Collections.Generic;
using Entities;
using Zenject;

namespace MVP.Models
{
    public class StatsModel
    {
        private readonly List<Stat> _stats;

        public event Action OnStatsChanged;

        [Inject]
        private StatsModel()
        {
            _stats = new List<Stat>
            {
                new()
                {
                    Header = "STATS PARAMETER 1",
                    Subheader = "SUB-HEADER",
                    Points = 99000
                },
                new()
                {
                    Header = "STATS PARAMETER 2",
                    Subheader = "SUB-HEADER",
                    Points = 990000
                },
                new()
                {
                    Header = "STATS PARAMETER 3",
                    Subheader = "SUB-HEADER",
                    Points = 9900000
                },
                new()
                {
                    Header = "STATS PARAMETER 4",
                    Subheader = "SUB-HEADER",
                    Points = 99000000
                },
                new()
                {
                    Header = "STATS PARAMETER 5",
                    Subheader = "SUB-HEADER",
                    Points = 990000000
                },
            };
        }

        public List<Stat> GetStats() => _stats;

        public void AddStat(Stat stat)
        {
            _stats.Add(stat);
            OnStatsChanged?.Invoke();
        }
    }
}