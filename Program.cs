using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//System.IO.File class is the full class name for File

namespace Assignment2._2._1
{    
    class Program
    {
        static string filepath = @"C:\Users\yang\Desktop\PCAD5\Projects\Week2\Assignment2.2.1\assignmentTestFile.txt";//file & file location of this program will work on
        static string name, address;
        static double age;
        static void Main(string[] args)
        {
            Conti();
        }
        static void Conti()
        {
            char conti = 'y';
            while (conti == 'y' || conti == 'Y')
            {
                Console.WriteLine("Please enter your name, age, and address");
                Console.Write("Please enter your name: ");
                name = Console.ReadLine();
                Console.Write("Please enter your age: ");
                age = Convert.ToDouble(Console.ReadLine());
                Console.Write("Please enter your address: ");
                address = Console.ReadLine();
                FileWritter();//may need mechanism to make this only run onetime? or not?
                ReadandOutput();//read all characters from filepath and display everything from the target file onto the console
                Console.WriteLine("Plese enter y or Y to continue or any other letter to exit");
                conti = Char.Parse(Console.ReadLine());
            }
            //call file handle methods
        }

        static void FileWritter()
        {
            StreamWriter streamWriter;
            if (File.Exists(filepath))//check if the file already exist
            {
                /*streamWriter = new StreamWriter(filepath);
                streamWriter.WriteLine($"Name: {name}");
                streamWriter.WriteLine($"Age: {age}");
                streamWriter.WriteLine($"Address: {address}");
                streamWriter.Close();*/
                File.AppendAllText(filepath, "Name: " + name + "\nAge: " + age + "\nAddress:" + address+"\n ");
                StringBuilder stringBuilder = new StringBuilder();stringBuilder.Append(Environment.NewLine);//how to add an empty line into text
                Console.WriteLine($"\nContent entered will be found at {filepath}");                
            }
            else
            {
                streamWriter = File.CreateText(filepath);//File.CreateText(filepath) will create or overwrite, written by streamWriter next line
                streamWriter.WriteLine($"Name: {name}");
                streamWriter.WriteLine($"Age: {age}");
                streamWriter.WriteLine($"Address: {address}");
                Console.WriteLine($"\nContent entered will be found at {filepath}");
                streamWriter.Close();//Closing a stream will flush it, and release any resources related to the stream, like a file handle.
            }
        }

        static void ReadandOutput()
        {
            StreamReader streamReader = new StreamReader(filepath);
            string userInput = streamReader.ReadToEnd();
            Console.WriteLine("\nYour input now as\n" + userInput);
            streamReader.Close();
        }
    }
}
