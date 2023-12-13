namespace DoadorOnline.Infrastructure;

public interface IEmailService
{
    void SendEmail(string subject, string body, string from);

    void SendEmailContactUs(string name, string from, string message);
}
