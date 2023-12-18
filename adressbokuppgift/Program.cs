using adressbokuppgift.Models;
using adressbokuppgift.Services;

class Program
{
    static void Main()
    {
        
        FileService fileService = new FileService(@"C:\my-projects\adressbok2023");
        
        List<Contact> existingList = fileService.ReadListFromJson(@"C:\my-projects\adressbok2023");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("## Min Adressbok ##");
            Console.WriteLine("1. Lägg till kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa enskild kontakt");
            Console.WriteLine("4. Uppdatera kontakt");
            Console.WriteLine("5. Radera kontakt");
            Console.WriteLine("0. Avsluta programmet");
            Console.WriteLine();
            Console.Write("Ditt val: ");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    {
                        Console.Write("Namn: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Efternamn: ");
                        string lastName = Console.ReadLine();
                        Console.Write("E-post: ");
                        string email = Console.ReadLine();
                        Console.Write("Adress: ");
                        string Adress = Console.ReadLine();
                        Console.Write("Telefonnummer: ");
                        string phoneNumber = Console.ReadLine();

                        Contact contact = new Contact(firstName, lastName, email, phoneNumber, Adress);
                        existingList.Add(contact);

                        fileService.SaveListToJson(existingList, fileService._filePath);
                        Console.WriteLine("Kontakt har lagts till i adressboken!");
                        Console.WriteLine();
                        break;
                        
                    }

                case "2":
                    {
                        Console.Clear();
                        var contacts = fileService.ReadListFromJson(fileService._filePath);
                        
                        if (contacts !=null)
                        {
                            for (int i = 0; i < contacts.Count; i++)
                            {
                                Console.WriteLine($"#{i + 1} {contacts[i].firstName} {contacts[i].lastName} ");
                            }
                            Console.ReadKey();
                        }
                        
                        break;
                    }

                case "3":

                case "4":

                case "5":

                case "0":
                    Environment.Exit(0);
                    break;
            }
        }

        
    }
}