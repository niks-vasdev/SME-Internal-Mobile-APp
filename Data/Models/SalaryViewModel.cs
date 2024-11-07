using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SalaryViewModel
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public double BasicSalary { get; set; }
        public double HousingAllowence { get; set; }
        public double ExperienceAllowence { get; set; }
        public double TransportationAllowence { get; set; }
        public double WaterAllowence { get; set; }
        public double PhoneAllowence { get; set; }
        public double CostOfLivingAllowence { get; set; }
        public double TotalSalary { get; set; }
        public double RetirementFundDeduction { get; set; } = 4;
        public double JobSecurityDeduction { get; set; } = 4;
        public double TotalDeduction { get; set; } = 8;
        public double NetSalary { get; set; }
        public Guid EmployeeId { get; set; }
        public double Reward { get; set; }
    }
}
