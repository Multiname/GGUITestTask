using Entities;
using ExternalSource;
using Zenject;

namespace MVP.Models
{
    public class AchievementsModel : ListModel<Achievement>
    {
        [Inject]
        public AchievementsModel(AchievementsDataSource dataSource) : base(dataSource) {}
    }
}