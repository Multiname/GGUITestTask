namespace Services
{
    public class AvatarService : SpriteServiceBase
    {
        protected override string FormKeyFromId(int id) => $"avatar_{id}";
    }
}