using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using batiment.Models;

public class EmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;
        email.Body = new TextPart("plain") { Text = body };

        using var smtp = new SmtpClient();

        // Connecter sans SSL
        await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, false); // false pour désactiver SSL/TLS

        // Authentification sécurisée (toujours préférable)
        await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);

        // Envoyer l'email
        await smtp.SendAsync(email);

        // Déconnexion du serveur
        await smtp.DisconnectAsync(true);
    }
}
