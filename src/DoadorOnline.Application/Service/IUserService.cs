namespace DoadorOnline.Application
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}