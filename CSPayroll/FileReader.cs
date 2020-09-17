using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSPayroll
{
    class FileReader
    {
        public List<Staff> ReadFile()
        {
            string path = "C:\\Users\\brbry\\source\\tests\\staff.txt";

            List<Staff> companyStaff = new List<Staff>();
            string[] result = new string[2];
            char separator = ',';

            if (File.Exists(path))
            {
                Console.WriteLine("Found staff.txt file");

                using StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    result = sr.ReadLine().Split(separator);
                    if (result[1] == "Manager")
                    {
                        companyStaff.Add(new Manager(result[0]));
                    }
                    else if (result[1] == "Admin")
                    {
                        companyStaff.Add(new Admin(result[0]));
                    }
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("---No file found---");
            }
            return companyStaff;
        }
    }
}
