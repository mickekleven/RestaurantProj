
namespace RestaurantProj
{
    /// <summary>
    /// Employees add or listing application
    /// </summary>
    static class Program
    {
        private static List<Employee> employees = new();

        /// <summary>
        /// Main entrance. Quick and dirty. 
        /// I know, to many responsibilities
        /// </summary>
        static void Main()
        {
            var isAsk = true;

            int _salary = 0;

            while (isAsk)
            {

                if (employees.Any())
                {
                    Console.WriteLine("Antal poster som har lagts till: {0}", employees.Count());
                }

                Console.Write("Anställd - Ange förnamn: ");
                var firstName = Console.ReadLine();

                Console.Write("Anställd - Ange efternamn: ");
                var lastName = Console.ReadLine();

                Console.Write("Anställd - Ange lön (Endast numeriska värden) : ");
                var salary = Console.ReadLine();

                while (!int.TryParse(salary, out _salary))
                {
                    Console.Write("OBS! Felaktigt format - Ange lön (Endast numeriska värden) : ");
                    salary = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && int.TryParse(salary, out _salary))
                {
                    employees.Add(new Employee { FirstName = firstName, LastName = lastName, Salary = _salary });
                }

                Console.Write("Vill du fortsätta och mata in anställda? (ja) n=nej");
                var continueAsk = Console.ReadLine();
                if (string.IsNullOrEmpty(continueAsk) || continueAsk.ToLower().Equals("ja"))
                {
                    Console.Clear();
                }
                else
                {
                    isAsk = false;
                }
            }


            var isAskEmpInfo = true;

            while (isAskEmpInfo)
            {
                Console.Write("Visa information om anställd: (alla) eller enge namn: ");
                var empInfo = Console.ReadLine();
                ShowEmpInfo(empInfo);

                Console.Write("Fortsätta att kontrollera anställda?: (ja) e=exit");
                var empContAsk = Console.ReadLine();

                if (string.IsNullOrEmpty(empContAsk))
                {
                    Console.Clear();
                }
                else
                {
                    Environment.Exit(0);
                }

            }
        }

        /// <summary>
        /// Show employee data
        /// </summary>
        /// <param name="_empInfo"></param>
        static void ShowEmpInfo(string _empInfo = "")
        {
            List<Employee> _tempCollection = new();

            if (string.IsNullOrEmpty(_empInfo))
            {
                _tempCollection = employees.Where(e => e.LastName.ToLower().Contains(_empInfo) ||
                                       e.LastName.ToLower().Contains(_empInfo)).ToList();
            }
            else
            {
                _tempCollection = employees;
            }

            foreach (var empData in _tempCollection)
            {
                Console.WriteLine($"FirstName: {empData.FirstName} | FirstName: {empData.LastName} | Salary: {empData.Salary} sek");
            }
        }

    }
}













