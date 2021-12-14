// See https://aka.ms/new-console-template for more information

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
        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
            }
        }
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}