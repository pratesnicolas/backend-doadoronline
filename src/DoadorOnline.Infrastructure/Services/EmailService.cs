using MimeKit.Text;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace DoadorOnline.Infrastructure;

public class EmailService : IEmailService
{
    public void SendEmail(string subject, string body, string to)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("contatodoadoroline@gmail.com"));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("contatodoadoronline@gmail.com", "pwop lyee gqsd mimw");
        smtp.Send(email);
        smtp.Disconnect(true);
    }

}
