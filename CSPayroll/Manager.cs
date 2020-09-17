using System;
using System.Collections.Generic;
using System.Text;

namespace CSPayroll
{
    class Manager : Staff
    {
        private const float mHourlyRate = 50;
        public int Allowance { get; private set; }
        public Manager(string name) : base(name, mHourlyRate)
        {
            // : base() passes parameters to base/parent constructor
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if(HoursWorked > 160)
            {
                TotalPay += Allowance;
            }
        }
        public override string ToString()
        {
            return $"mHourlyRate: {mHourlyRate}, Allowance: {Allowance}";
        }
    }
}
