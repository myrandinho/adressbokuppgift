using adressbokuppgift.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adressbokuppgift.Services
{
    public class FileService(string filePath)
    {
        public readonly string _filePath = filePath;

        public List<Contact> ReadListFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Contact>>(jsonContent) ?? new List<Contact>();
                }
                else
                {
                    Console.WriteLine("Filen finns inte. Skapar en ny fil...");
                    return new List<Contact>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid läsning av JSON-fil: {ex.Message}");
                return new List<Contact>();
            }
        }

        public void SaveListToJson(List<Contact> list, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false)) 
                {
                    string jsonContent = JsonConvert.SerializeObject(list);
                    sw.Write(jsonContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skrivning till JSON-fil: {ex.Message}");
            }
        }

    }


}
