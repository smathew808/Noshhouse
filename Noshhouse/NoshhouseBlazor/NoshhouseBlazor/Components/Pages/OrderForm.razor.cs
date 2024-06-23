using NoshhouseBlazor.Helpers;
using NoshhouseBlazor.Models;

namespace NoshhouseBlazor.Components.Pages
{
    public partial class OrderForm
    {
        Order order = new();
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string orderDesc = string.Empty;

        public void SubmitForm()
        {
            SendEmail();
        }

        public void SendEmail()
        {
            try
            {
                string emailBody = $"{firstName}\r\n" +
                                    $"{lastName}\r\n" +
                                    $"{email}\r\n" +
                                    $"{orderDesc}";

                var blah = new GmailServiceHelper();
                blah.SendEmail("smathew808@gmail.com", "Testing", emailBody);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
