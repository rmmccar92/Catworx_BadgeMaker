// See https://aka.ms/new-console-template for more information

// Demo URL https://placekitten.com/300/300

namespace CatWorx.BadgeMaker
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to populate the database with employees? (y/n)");
            string input = Console.ReadLine();
            if (input == "y")
            {
                List<Employee> employees = PeopleFetcher.GetFromAPI();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                Util.MakeBadges(employees);
            }
            else
            {
                List<Employee> employees = PeopleFetcher.GetEmployees();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                Util.MakeBadges(employees);
            }
        }
    }
}