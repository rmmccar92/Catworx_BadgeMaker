// using System;
// using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                Console.WriteLine("Please enter a first name: (leave empty to exit): ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                Console.WriteLine("Please enter a last name: (leave empty to exit): ");
                string input2 = Console.ReadLine();
                Console.WriteLine("Please enter an id: (leave empty to exit): ");
                string input3 = Console.ReadLine();
                int idInput = int.Parse(input3);
                Console.WriteLine("Please enter a Photo URL: (leave empty to exit): ");
                string input4 = Console.ReadLine();
                // Create a new Employee instance
                Employee currentEmployee = new Employee(input, input2, idInput, input4);
                employees.Add(currentEmployee);

            }
            return employees;
        }
        public static List<Employee> GetFromAPI()
        {
            List<Employee> employees = new List<Employee>();
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                Console.WriteLine(json.SelectToken("results"));
                foreach (JToken token in json.SelectToken("results"))
                {
                    // Parse JSON data
                    Employee emp = new Employee
                    (
                      token.SelectToken("name.first").ToString(),
                      token.SelectToken("name.last").ToString(),
                      Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                      token.SelectToken("picture.large").ToString()
                    );
                    employees.Add(emp);
                }

            }
            return employees;
        }

    }
}