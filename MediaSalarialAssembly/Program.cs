using MediaSalarialAssembly.Entities;
namespace MediaSalarialAssembly
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary:");
            double salaryStart = double.Parse(Console.ReadLine());
            List<Employee> list = new List<Employee>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2]);
                        list.Add(new Employee(name, email, salary));
                    }
                }
                var emails = list.Where(p => p.Salary > salaryStart).OrderBy(p => p.Email).Select(p => p.Email);
                var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                Console.WriteLine("Email of people whose salary is more than " + salaryStart + ":");
                foreach(string email in emails)
                {
                    Console.WriteLine(email);
                }
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }
    }
}