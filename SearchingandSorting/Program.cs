using System.Drawing;

namespace SearchingandSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ps =@"C:\Users\saivignesh\Desktop\class.txt";
            FileStream ds = new FileStream(ps,FileMode.Open,FileAccess.Read);
            StreamReader rs = new StreamReader(ds);
            List<Student> list = new List<Student>();
            while (!rs.EndOfStream) {
                string k=rs.ReadLine();
                char[] c = new char[] {' ','\t'};
                string[] man = k.Split(c, StringSplitOptions.None);
                Student s = new Student();
                s.Name = man[0];
                s.Class = Convert.ToInt32(man[1]);
                list.Add(s);
            }
            rs.Close();
            ds.Close();
            rs.Dispose();
            ds.Dispose();

            start:
            Console.Write(" 1.SortbyClass\n 2.SortbyName\n 3.SearchbyName\n 4.SearchByClass\n 5.Display\n");
            Console.WriteLine("Enter your Choice");
            int ch=Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Sort by Class");
                    var par=list.OrderBy(list=>list.Class).ToList();
                    Console.ForegroundColor=ConsoleColor.Red;
                    foreach (Student s in par)
                    {
                        Console.Write($"{s.Name} studying in {s.Class}\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("Sort by Name");
                    var par1 = list.OrderBy(list => list.Name).ToList();
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (Student s in par1)
                    {
                        Console.Write($"{s.Name} studying in {s.Class}\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("Search by Name");
                    foreach (Student s in list)
                    {
                        Console.Write($"{s.Name} studying in {s.Class} \n");
                    }
                    Console.WriteLine("Enter Name to search");
                    string pr = Console.ReadLine();
                    var pit= list.Where(list => list.Name==pr).ToList();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (pit!=null)
                    {
                        foreach(Student s in pit) { 
                            Console.Write($"{s.Name} studying in {s.Class} \n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No students name found");
                    }
                    break;
                case 4:
                    Console.WriteLine("Search By Class");
                    foreach (Student s in list)
                    {
                        Console.Write($"{s.Name} studying in {s.Class} \n");
                    }
                    Console.WriteLine("Enter Class to search");
                    int pr1 = Convert.ToInt32(Console.ReadLine());
                    var pit1 = list.Where(list => list.Class == pr1).ToList();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (pit1!= null)
                    {
                        foreach (Student s in pit1)
                        {
                            Console.Write($"{s.Name} studying in {s.Class}\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No students in Class");
                    }
                    break;
                case 5:
                    Console.WriteLine("Display");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (Student s in list)
                    {
                        Console.Write($"{s.Name} studying in {s.Class}  \n");
                    }
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Yes to Continue");
            string pnt= Console.ReadLine();
            if (pnt == "Yes")
            {
                goto start;
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Class { get; set; }
    }
}