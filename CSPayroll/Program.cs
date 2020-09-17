using System;
using System.Collections.Generic;

namespace CSPayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Of Beginnings and the Names of Things\n\n");

            List<Staff> companyStaff = new List<Staff>();

            FileReader fr = new FileReader();

            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.Write("Please enter the year: ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                    if(year < 0 || 2020 < year)
                    {
                        Console.WriteLine("Error. Must enter a valid year.\n");
                        year = 0;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Error. Must enter a valid year.\n");
                }
            }
            while (month == 0)
            {
                Console.Write("Please enter the month: ");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if(month < 1 || 12 < month)
                    {
                        Console.WriteLine("Error. Must enter a valid month.\n");
                        month = 0;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Error. Must enter a valid month.\n");
                }
            }

            companyStaff = fr.ReadFile();

            for(int i = 0; i < companyStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"\nEnter the hours worked for {companyStaff[i].NameOfStaff}: ");
                    companyStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    companyStaff[i].CalculatePay();
                    Console.WriteLine(companyStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(companyStaff);
            ps.GenerateSummary(companyStaff);
        }
    }
}
