using System.Collections.Generic;
using System.Linq;
using Entities;
using ExternalSource;
using Zenject;

namespace MVP.Models
{
    public class MatchHistoryModel : ListModel<Match>
    {
        [Inject]
        public MatchHistoryModel(MatchHistoryDataSource dataSource) : base(dataSource) {}
        
        public List<Match> GetRecentMatches(int limit) => List.TakeLast(limit).Reverse().ToList();
    }
}