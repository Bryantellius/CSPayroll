using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CSPayroll
{
    class PaySlip
    {
        private int month;
        private int year;
        enum MonthsOfYear
        {
            JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }
        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }
        public void GeneratePaySlip(List<Staff> companyStaff)
        {
            Console.WriteLine("Generating PaySlip...\n");
            string path;
            foreach(Staff e in companyStaff)
            {
                path = "C:\\Users\\brbry\\source\\tests\\" + e.NameOfStaff + ".txt";
                using StreamWriter sw = new StreamWriter(path, false);

                sw.WriteLine($"PAYSLIP FOR {(MonthsOfYear)month} {year}");
                sw.WriteLine("============");
                sw.WriteLine($"Name Of Staff: {e.NameOfStaff}");
                sw.WriteLine($"Hours Worked: {e.HoursWorked}\n");
                sw.WriteLine($"Basic Pay: {e.BasicPay:C}");
                if (e.GetType() == typeof(Manager)) sw.WriteLine($"Allowance: {((Manager)e).Allowance:C}");
                else sw.WriteLine($"Overtime: {((Admin)e).Overtime:C}\n");
                sw.WriteLine("============");
                sw.WriteLine($"Total Pay: {e.TotalPay:C}");
                sw.WriteLine("============");

                sw.Close();
            }
        }
        public void GenerateSummary(List<Staff> companyStaff)
        {
            Console.WriteLine("Generating Summary...\n");
            var result = from employee in companyStaff where employee.HoursWorked < 10 orderby employee.NameOfStaff ascending select employee;

            string path = "C:\\Users\\brbry\\source\\tests\\summary.txt";

            using StreamWriter sw = new StreamWriter(path, false);
            sw.WriteLine("Staff with less than 10 working hours\n");
            foreach(Staff e in result)
            {
                sw.WriteLine($"Name of Staff: {e.NameOfStaff}, Hours Worked: {e.HoursWorked}");
            }
            sw.Close();
        }
        public override string ToString()
        {
            return $"Month: {month}, Year: {year}";
        }
    }
}
