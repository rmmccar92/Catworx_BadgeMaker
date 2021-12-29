// See https://aka.ms/new-console-template for more information

// Demo URL https://placekitten.com/300/300

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static List<Employee> GetEmployees()
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

        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            Util.MakeBadges(employees);
        }
    }
}