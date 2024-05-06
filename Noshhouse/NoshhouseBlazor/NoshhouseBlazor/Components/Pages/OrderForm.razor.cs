using NoshhouseBlazor.Models;
using System.Net;
using System.Net.Mail;

namespace NoshhouseBlazor.Components.Pages
{
    public partial class OrderForm
    {
        private string FormSubmittedText = string.Empty;
        private string SenderEmail = "ryan.hane@ethereal.email";
        private string SenderPassword = string.Empty;
        private string RecipientEmail = "ryan.hane@ethereal.email";
        

        Order order = new();
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string orderDesc = string.Empty;

        public void SubmitForm()
        {
            FormSubmittedText = $"{firstName}, {lastName}, {email}, {orderDesc}";
        }

        public void SendEmail()
        {
            try
            {
                using (MailMessage mail = new())
                {
                    mail.From = new MailAddress(SenderEmail);
                    mail.To.Add(RecipientEmail);
                    mail.Subject = "Test sending email from Blazor app 2";
                    mail.Body = "<h2>Testing again</h2>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.ethereal.email", 587))
                    {
                        smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
