

namespace adressbokuppgift.Models
{
    public class Contact
    {
        public Contact(string firstName, string lastName, string phoneNumber, string email, string adress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            Email = email;
            Adress = adress;
        }

        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string phoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Adress { get; set; } = null!;

    }
}
