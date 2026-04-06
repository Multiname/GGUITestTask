namespace Services.SpriteServices
{
    public class AchievementIconService : SpriteServiceBase
    {
        protected override string FormKeyFromId(int id) => $"achievement_icon_{id}";
    }
}