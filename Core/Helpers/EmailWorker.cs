using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace Core.Helpers
{
    public static class EmailWorker
    {
        private static readonly int _port = 587;
        private static readonly string _host = "smtp.gmail.com";

        private static readonly string _displayName = "HeartBeat Team";
        private static readonly string _fromEmail = "spotifyconfirm0@gmail.com";
        private static readonly string _password = "mtywwskwmoysrbep";

        private static async Task SendAsync(MailMessage email)
        {
            email.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(_host, _port);
            smtp.Credentials = new NetworkCredential(_fromEmail, _password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(email);
        }

        public static async Task SendWelcomeEmail(string toEmail)
        {
            MailAddress from = new MailAddress(_fromEmail, _displayName);
            MailAddress to = new MailAddress(toEmail);
            MailMessage email = new MailMessage(from, to);

            email.Subject = "Welcome to HeartBeat!";
            email.Body = "<!DOCTYPE html><html><head><meta charset='UTF-8'><title>Welcome Page</title></head><body><div class='container' style='max-width: 600px; margin: 0 auto; padding: 40px; background-color: #ffffff; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); text-align: center;'><img class='vinyl-image' style='width: 40%; margin-bottom: 30px;' src='https://media2.giphy.com/media/XZjZPj7UrG0WLxrpDe/giphy.gif?cid=6c09b9524agxw7jxrofauefnidhiani4m2fpeq3tvui8k41u&rid=giphy.gif&ct=s' alt='Vinyl Player'><h1 style='color: #333333; margin-bottom: 20px; font-size: 24px; font-weight: 400; line-height: 25px; letter-spacing: 0em; text-align: center;'>Welcome to HeartBeat!</h1><p style='color: #666666; font-size: 18px; line-height: 1.5; margin-bottom: 30px;'>Thank you for joining us. We are excited to have you on board.</p><p style='color: #666666; font-size: 18px; line-height: 1.5; margin-bottom: 30px;'>Stay tuned for exciting updates and new features.</p><a href='https://heartBeat.com' style='color: #000000; background-color: #D9D9D9; padding: 10px 20px; text-decoration: none; border-radius: 10px; font-size: 20px; line-height: 37px; letter-spacing: 0em; text-align: center;'>Continue to HeartBeat</a></div></body></html>"; ;
            await SendAsync(email);
        }

        public static async Task SendVerifyEmail(string toEmail, string uniqueVerifiacationCode)
        {
            MailAddress from = new MailAddress(_fromEmail, _displayName);
            MailAddress to = new MailAddress(toEmail);
            MailMessage email = new MailMessage(from, to);

            email.Subject = "Confirm your email!";
            email.Body = "<!DOCTYPE html><html><head><meta charset='UTF-8'><title>Confirming email</title></head><body><div class='container' style='max-width: 600px; margin: 0 auto; padding: 40px; background-color: #ffffff; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); text-align: center;'><img class='vinyl-image' style='width: 40%; margin-bottom: 30px;' src='https://media2.giphy.com/media/XZjZPj7UrG0WLxrpDe/giphy.gif?cid=6c09b9524agxw7jxrofauefnidhiani4m2fpeq3tvui8k41u&rid=giphy.gif&ct=s' alt='Vinyl Player'><h1 style='color: #333333; margin-bottom: 20px; font-size: 24px; font-weight: 400; line-height: 25px; letter-spacing: 0em; text-align: center;'>Confirm your email on HeartBeat!</h1><p style='color: #666666; font-size: 18px; line-height: 1.5; margin-bottom: 30px;'>You received this email because you registered on the HeartBeat music platform, for a full experience you need to confirm your email, you can do it by simply clicking the button below. If you did not register and receive this email by mistake, you can delete this email and forget about it.</p><a href='http://localhost:3000/confirm/" + toEmail + "/" + uniqueVerifiacationCode + "' style='color: #000000; background-color: #D9D9D9; padding: 10px 20px; text-decoration: none; border-radius: 10px; font-size: 20px; line-height: 37px; letter-spacing: 0em; text-align: center;'>Confirm my email</a></div></body></html>";
            await SendAsync(email);
        }
    }
}