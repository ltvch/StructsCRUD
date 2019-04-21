using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.Design;

namespace CRUDOnSructurs
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();




            Console.Write("Insert student NAME : ");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
                student.Name = name;
            else
                Console.WriteLine("Repeat Insert Name");


            Console.WriteLine($"\nStudent name is - {student.Name}");


            Console.Write("Insert student LASTNAME : ");
            string lastname = Console.ReadLine();
            if (!string.IsNullOrEmpty(lastname))
                student.LastName = lastname;
            else
                Console.WriteLine("Repeat Insert Name");


            Console.WriteLine($"\nStudent name is - {student.Name}");
            Console.WriteLine($"\nStudent lastname is - {student.LastName}");

            // Get the type handle of a specified class.
            Type myType = typeof(Student);

            // Get the fields of the specified class.
            FieldInfo[] myField = myType.GetFields();

            Console.WriteLine(myField.Count());
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
        }
    }
}
