namespace DoadorOnline.Infrastructure;

public interface IEmailService
{
    void SendEmail(string subject, string body, string from);
}
