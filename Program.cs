using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StructCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudent = 0;
            int[] grade = new int[4];
            string entered = string.Empty;
            string titleStudent = "Enter the FirstName, LastName, Date of Birth, Contract Number And Grade Students";

            #region INSERT STUDENT
            Console.WriteLine(new string('#', titleStudent.Length+4));
            Console.WriteLine($"# {titleStudent} #");
            Console.WriteLine(new string('#', titleStudent.Length+4));

            Console.Write("First Name :");
            string fName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fName) || !Regex.Match(fName, "[A-Z][a-zA-Z]*$").Success)
            {
                Console.WriteLine("Name can't be empty or uncorrect! Input your name once more ...");
                fName = Console.ReadLine();
            }

            Console.Write("Last Name : ");
            string lastName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(lastName) || !Regex.Match(lastName, "[a-zA-z]+(['-][a-zA-Z]+)*").Success)
            {
                Console.WriteLine("Last Name can't be empty or uncorrect! Input your lastName once more ...");
                lastName = Console.ReadLine();
            }           

            Console.Write("Date of Birth in format dd/MM/yyyy: ");
            string dateOfBirth = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                dateOfBirth = Console.ReadLine();
            }

            Console.Write("Contract Number have only number : ");
            string contract = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(contract) || !Regex.Match(contract, "^[0-9]+$").Success)
            {
                Console.WriteLine("Number can't be empty or uncorrect! Input your name once more ...");
                contract = Console.ReadLine();
            }
            
            Console.Write("Student grades for 4 sessions : \n");
            for (int i = 0; i < grade.Length; ++i)
            {
                Console.Write(" {0} : ", i+1);
                grade[i] = Convert.ToInt32(Console.ReadLine());
            }

            //inserting
            Student student = new Student
            {
                FirstName = fName,
                LastName = lastName,
                DateOfBirth = dt,
                ContractNumber = Convert.ToInt32(contract),
                Grade = new int[grade.Length] // инициализируем поле структуры как массив 
            };
            Array.Copy(grade, student.Grade, grade.Length);
            #endregion INSERT STUDENT

            #region INSERT GROUP
            string titleGroup = "\nEnter the student group number and name of branсh(profession)";

            Console.WriteLine(new string('#', titleGroup.Length + 4));
            Console.WriteLine($"# {titleGroup} #");
            Console.WriteLine(new string('#', titleGroup.Length + 4));

            Console.Write("Student group number : ");
            string groupNumber = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(groupNumber) /*|| !Regex.Match(groupNumber, "/^[a-z0-9_-]{3,5}$/").Success*/) //Буквы, цифры, дефисы и подчёркивания, 3-6 char
            {
                Console.WriteLine("Student group number can't be empty or uncorrect! Input group number againe ...");
                groupNumber = Console.ReadLine();
            }

            Console.Write("Name of branсh(profession) : ");
            string branch = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(branch)) //Буквы, цифры, дефисы и подчёркивания, 3-6 char
            {
                Console.WriteLine("Branch can't be empty! Input group number againe ...");
                branch = Console.ReadLine();
            }

            //inserting
            Group group = new Group
            {
                GroupNumber = groupNumber,
                Branch = branch,
                students = new Student[0] // инициализируем поле структуры как массив 
            };
            Array.Resize(ref group.students, group.students.Length+1);
            group.Add(group.students, student);

            #endregion INSERT GROUP


            Console.WriteLine($"\n{new string('*', titleStudent.Length + 4)}");
            
            Console.WriteLine($"Contract Number : {student.ContractNumber}\nFirst Name : {student.FirstName}\nLast Name : {student.LastName}\nDate of Birth : {student.DateOfBirth}\nGrade : {string.Join(", ", student.Grade)}");

            Console.WriteLine(group.students.Count());
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
        }
    }
}
