using Entities;
using ExternalSource.ListDataSources;
using Zenject;

namespace MVP.Models.ListModels
{
    public class StatsModel : ListModel<Stat>
    {
        [Inject]
        public StatsModel(StatsDataSource dataSource) : base(dataSource) {}
        
        public void UpdateStatPoints(int index, long points)
        {
            List[index].points = points;
            InvokeOnChanged();
        }
    }
}