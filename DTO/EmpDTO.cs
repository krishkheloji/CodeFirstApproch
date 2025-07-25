using JunBatchCodeFirstApproachImpl.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JunBatchCodeFirstApproachImpl.DTO
{
    public class EmpDTO
    {
        public int eid { get; set; }
        public string ename { get; set; } //EmpName
        public string email { get; set; }
        public double esalary { get; set; } //EmpSalaryDetails
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
