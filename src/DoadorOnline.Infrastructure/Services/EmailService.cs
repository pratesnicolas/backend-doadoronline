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

        BodyBuilder bodyBuilder = new();
        bodyBuilder.HtmlBody = GetBodyEmailHtml(subject, to, body);
        email.Subject = subject;
        email.Body = bodyBuilder.ToMessageBody();
        
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("contatodoadoronline@gmail.com", "pwop lyee gqsd mimw");
        smtp.Send(email);
        smtp.Disconnect(true);
    }


    public void SendEmailContactUs(string name, string from, string message)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(from));
        email.To.Add(MailboxAddress.Parse("contatodoadoronline@gmail.com"));
        email.Subject = $"{name} - {email} - Contato via site";
        email.Body = new TextPart(TextFormat.Html) { Text = message };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("contatodoadoronline@gmail.com", "pwop lyee gqsd mimw");
        smtp.Send(email);
        smtp.Disconnect(true);
    }



    private string GetBodyEmailHtml(string subject,
                                    string name,
                                    string message)
    {
        var bodyHtml = $@"<!DOCTYPE html>
                            <html lang=""en"">
                            <head>
                                <meta charset=""UTF-8"">
                                <title>Email Template</title>
                                <style>
                                    body {{
                                        font-family: Arial, sans-serif;
                                        line-height: 1.6;
                                        background-color: #f4f4f4;
                                        margin: 0;
                                        padding: 20px;
                                    }}
                                    .container {{
                                        max-width: 600px;
                                        margin: 0 auto;
                                        background: #fff;
                                        padding: 30px;
                                        border-radius: 8px;
                                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                                    }}

                                    .logo {{
                                        text-align: center;
                                        margin-bottom: 20px;
                                    }}

                                    .logo img {{
                                        max-width: 100px;
                                        height: auto;
                                    }}

                                    h1 {{
                                        color: #333;
                                    }}

                                    p {{
                                        color: #666;
                                    }}

                                    .footer {{
                                        margin-top: 30px;
                                        font-size: 12px;
                                        text-align: center;
                                        color: #999;
                                    }}
                                </style>
                            </head>

                            <body>
                                <div class=""container"">
                                    <div class=""logo"">
                                        <img src=""https://frontend-doador-online.vercel.app/static/media/logo.7eeb01c2674556ab7161.png"" alt=""Logo"">
                                    </div>
                                    <h3>{subject}</h3>
                                    <p>Olá, {name}!</p>
                                    <p>{message}</p>
                                    <div class=""footer"">
                                        <p>Este é um email automático. Por favor, não responda a este email.</p>
                                    </div>
                                </div>
                            </body>
                            </html>";

        return bodyHtml;
    }
}
