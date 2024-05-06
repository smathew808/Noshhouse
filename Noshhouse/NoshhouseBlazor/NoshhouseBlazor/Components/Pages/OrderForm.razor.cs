using NoshhouseBlazor.Models;

namespace NoshhouseBlazor.Components.Pages
{
    public partial class OrderForm
    {
        private string FormSubmittedText = string.Empty;

        Order order = new();
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string orderDesc = string.Empty;

        void SubmitForm()
        {
            FormSubmittedText = $"{firstName}, {lastName}, {email}, {orderDesc}";
        }
    }

}
