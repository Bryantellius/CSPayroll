using System;
using System.Collections.Generic;
using System.Text;

namespace CSPayroll
{
    class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float aHourlyRate = 30;
        public float Overtime { get; private set; }
        public Admin(string name) : base(name, aHourlyRate) { }
        public override void CalculatePay()
        {
            base.CalculatePay();
            Overtime = overtimeRate * (HoursWorked - 160);
            if(HoursWorked > 160)
            {
                TotalPay += Overtime;
            }
        }
        public override string ToString()
        {
            return $"overtimeRate: {overtimeRate}, aHourlyRate: {aHourlyRate}, Overtime: {Overtime}";
        }
    }
}
