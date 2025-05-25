namespace BeanSceneApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public Contact(string address, string city, string email, string phone)
        {
            Address = address;
            City = city;
            Email = email;
            Phone = phone;
        }
    }
}
