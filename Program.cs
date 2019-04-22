 static void Main(string[] args)
        {
            Student student = new Student();
            student.Grade = new int[4];
            string entered = string.Empty;
            string title = "Enter the FirstName, LastName, Date of Birth, Contract Number And Grade Students";

            Console.WriteLine(new string('#', title.Length+4));
            Console.WriteLine($"# {title} #");
            Console.WriteLine(new string('#', title.Length+4));

            Console.Write("First Name : ");
            student.FirstName = Console.ReadLine();

            Console.Write("Last Name : ");
            student.LastName = Console.ReadLine();

            Console.Write("Date of Birth in format dd/MM/yyyy: ");
            student.DateOfBirth = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(student.DateOfBirth, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                student.DateOfBirth = Console.ReadLine();
            }

            Console.Write("Contract Number : ");
            student.ContractNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Student grades for 4 sessions : \n");
            for (int i = 0; i < student.Grade.Length; ++i)
            {
                Console.Write(" {0} : ", i+1);
                student.Grade[i] = Convert.ToInt32(Console.ReadLine());
            }

            /*
            //inserting
            Student student = new Student
            {
                FirstName = fName,
                LastName = lName,
                DateOfBirth = dt,
                ContractNumber = contract,
                Grade = grades.Clone()
            };
            */
            Console.WriteLine($"\n{new string('*', title.Length + 4)}");
            
            Console.WriteLine($"Contract Number : {student.ContractNumber}\nFirst Name : {student.FirstName}\nLast Name : {student.LastName}\nDate of Birth : {student.DateOfBirth}\nGrade : {string.Join(" ,", student.Grade)}");

            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
