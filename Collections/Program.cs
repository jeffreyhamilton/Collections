using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>();

            students.Add("Sue");
            students.Add("Bill");
            students.Add("Allen");

            Console.WriteLine(students.Count);

            students.Add("Marry");
            students.Add("Beth");

            Console.WriteLine(students.Count);

            //making a list all at once
            List<string> studentsTwo = new List<string>() { "Sue", "Bill", "Allen", "Beth", "Mary" };

            //making a list out of another list
            List<string> studentsThree = new List<string>(studentsTwo);

            //Convert an list into array

            string[] studentArray = students.ToArray();

            //printing the contents of list ("name" can be replaced with any word)
            foreach(string name in students)
            {
                Console.WriteLine(name);
            }

            //inserting a name (this inserts DingDong between Sue and Bill)
            students.Insert(1, "DingDong");
            foreach (string name in students)
            {
                Console.WriteLine(name);
            }

            //removing a name (this removes Bill)
            students.RemoveAt(2);
            //we could have also removed Bill like this...
            /*
            students.Remove("Bill");
            */
            foreach (string name in students)
            {
                Console.WriteLine(name);
            }

            //call method below and apply it
            List<int> resultsOfGetPowers = new List<int>(GetPowersOf2(4));
            foreach (int number in resultsOfGetPowers)
            {
                Console.WriteLine(number);
            }

            //how to sort a list
            students.Sort();
            //this list is now sorted alphabetically. 
            //The sort method will choose the most obvious way to sort a list if not given a specific sort method


            //below we create an object list of class Student and students to it and write them out.
            /*Becuase of how we worte the class it sorts by name then by grade 
             * so names that are the same will be arraganged with lowest grade first
             */
            List<Student> studentsFromClass = new List<Student>
            {
                new Student() {Name = "Sally" , GradeLevel = 3},
                new Student() {Name = "Bob" , GradeLevel = 3},
                new Student() {Name = "Sally" , GradeLevel = 2},
                new Student() {Name = "Adam" , GradeLevel = 3},
                new Student() {Name = "Craig" , GradeLevel = 3},
                new Student() {Name = "Craig" , GradeLevel = 2}
            };

            studentsFromClass.Sort();

            foreach(Student individual in studentsFromClass)
            {
                Console.WriteLine($"{individual.Name} is in grade {individual.GradeLevel}");
            }

        }


        //Create a static method named GetPowersOf2 that returns a list of integers of type List<int> 
        //containing the powers of 2 from 0 to the value passed in. For example, if 4 is passed in, 
        //the method should return this list of integers: { 1, 2, 4, 8, 16 }. The System.Math.Pow method will come in handy.

        public static List<int> GetPowersOf2(int input)
        {
            List<int> returnList = new List<int>();
            for (int i = 0; i < input + 1; i++)
            {
                returnList.Add((int)Math.Pow(2, i));
            }
            return returnList;

        }

        /*The following class Student implements the IComparable interface.  It then pass in the type parameter Student.
         * This is specifiying that Student can be compared with other objects of type Student.
         */
        class Student : System.IComparable<Student>
        {
            public string Name { get; set; }
            public int GradeLevel { get; set; }

            public int CompareTo (Student that)
            {
                int result = this.Name.CompareTo(that.Name);

                if(result == 0)
                {
                    result = this.GradeLevel.CompareTo(that.GradeLevel);
                }

                return result;
            }
        }
    }
}
