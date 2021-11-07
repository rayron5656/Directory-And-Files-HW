using Chilkat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Directory_And_Files_HW
{
    class comperbySize : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string item in Directory.GetDirectories(@"C:\").Take(10)) //First 10 folders QST 1
            {
                Console.WriteLine(item);


            }

            GetThreeFiles(@"C:\Documents\.Net\"); //Qst 2


            List<student> students = new List<student>(); // QST3

            students.Add(new student("456789","Ron",26));
            students.Add(new student("87654", "Dor",29));
            students.Add(new student("342266", "Regev",75));
            students.Add(new student("87465353", "Itamar",34));

            var str = JsonSerializer.Serialize(students); 

            File.WriteAllText("Students.JSON", str); //QST3

            var streamWriter = new StreamWriter(@"C:\Documents\.Net\SaveToCSV");

            using (streamWriter)
            {
                foreach (student S in students)
                {
                    streamWriter.WriteLine(S.ID+","+S.Name+","+S.Age+","); //QSt 5
                }
            }

            var streamreader = new StreamReader(@"C:\Documents\.Net\SaveToCSV", true);

            using (streamreader)
            {
                string Line = string.Empty;
                while (Line != null)
                {
                    Line = streamreader.ReadLine();  // Qst 6
                    Console.WriteLine(Line);
                }
            }

        }
        static public void GetThreeFiles(string path) //QST 2
        {

            List<FileInfo> Files = new List<FileInfo>();

            foreach (string Path in Directory.GetFiles(path))
            {

                Files.Add(new FileInfo(Path));

            }


            Files.Sort(new comperbySize());


            foreach (FileInfo FI in Files.Take(3))
            {
                Console.WriteLine(FI.Name + " " + FI.LastWriteTimeUtc);
            }
        }
    }
}
