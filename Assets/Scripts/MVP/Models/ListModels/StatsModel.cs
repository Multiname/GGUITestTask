using Entities;
using ExternalSource;
using Zenject;

namespace MVP.Models
{
    public class StatsModel : ListModel<Stat>
    {
        [Inject]
        public StatsModel(StatsDataSource dataSource) : base(dataSource) {}
    }
}