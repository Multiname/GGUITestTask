using Entities;
using ExternalSource.ListDataSources;
using Zenject;

namespace MVP.Models.ListModels
{
    public class AchievementsModel : ListModel<Achievement>
    {
        [Inject]
        public AchievementsModel(AchievementsDataSource dataSource) : base(dataSource) {}
    }
}