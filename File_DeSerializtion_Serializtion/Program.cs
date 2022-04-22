using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace File_DeSerializtion_Serializtion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 16

            //DirectoryInfo d = new DirectoryInfo(@"C:\");
            //int count = 0;
            //foreach (var name in d.GetDirectories())
            //{

            //    Console.WriteLine(name.Name);
            //    count++;

            //    if (count == 10)
            //        break;
            //}


            #endregion

            #region Question 17

            //Get3LargestFiles("corsair ssd toolbox");

            #endregion

            Car c1 = new Car("Corola", "Toyota", 2012, "White", 1111, 5);
            Car c2 = new Car("Civic", "Honda", 2014, "Black", 2424, 5);
            Car c3 = new Car("Ibiza", "Seat", 2018, "Grey", 1212, 4);

            Car[] carArr = new Car[] { c1, c2, c3 };

            XmlSerializer myXml = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream(@"D:\NewTxt.txt", FileMode.Create))
            {
                myXml.Serialize(file, c1);
            }

            using (Stream file = new FileStream(@"D:\NewTxt.txt", FileMode.Append))
            {
                myXml.Serialize(file, c2);
            }

            using (Stream file = new FileStream(@"D:\NewArrayTxt.txt", FileMode.Create))
            {
                foreach (var car in carArr)
                {
                    myXml.Serialize(file, car);
                }
            }


        }


        static void Get3LargestFiles(string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\");
            bool checkIfExist = false;
            List<FileInfo> LargestFiles = new List<FileInfo>();
            #region Check if file exist in the Directory 

            foreach (var file in dir.GetDirectories())
            {

                if (file.Name.ToLower() == folderName.ToLower())
                {
                    checkIfExist = true;
                    dir = new DirectoryInfo(@$"D:\{folderName}");
                    break;
                }


            }

            if (checkIfExist == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Couldn't found the file or the file does not exist");
                Console.ForegroundColor = ConsoleColor.White;
            }

            #endregion

            #region Check which file is the biggest

            foreach (var file in dir.GetFiles())
            {
                foreach (var file2 in dir.GetFiles())
                {
                    if (file.Length > file2.Length && !LargestFiles.Contains(file) && LargestFiles.Count < 3)
                    {
                        LargestFiles.Add(file);
                    }
                    else if (file2.Length > file.Length && LargestFiles.Contains(file))
                    {
                        LargestFiles[LargestFiles.IndexOf(file)] = file2;
                    }

                }
            }

            //Printing the Largest Files
            foreach (var file in LargestFiles)
            {
                Console.WriteLine(file);
            }


            #endregion

        }
    }
}
