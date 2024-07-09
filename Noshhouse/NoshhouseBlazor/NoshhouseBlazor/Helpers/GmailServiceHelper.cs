using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;

namespace NoshhouseBlazor.Helpers
{
    public class GmailServiceHelper
    {
        private GmailService _service;

        public GmailServiceHelper()
        {
            _service = GetGmailService();
        }

        public static GmailService GetGmailService()
        {
            GmailAuthenticator authenticator = new();
            UserCredential credential = authenticator.GetCredentials();

            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Your Application Name",
            });
        }

        public void SendEmail(string from, string subject, string body)
        {
            var msg = new Google.Apis.Gmail.v1.Data.Message();
            var to = "mrfender95@gmail.com";

            msg.Raw = CreateEmailMessage(from, to, subject, body);
            _service.Users.Messages.Send(msg, "me").Execute();
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        private static string CreateEmailMessage(string from, string to, string subject, string body)
        {
            var msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress(from);
            msg.To.Add(to);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;

            var msgStr = $"From: {from}\r\n" +
                 $"To: {to}\r\n" +
                 $"Subject: {subject}\r\n" +
                 $"Content-Type: text/html; charset=UTF-8\r\n\r\n" +
                 $"{body}";

            return Base64UrlEncode(msgStr);
        }
    }
}
