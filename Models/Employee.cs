using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Employee
    {
        [Key]
        public int eid { get; set; }
        public string ename { get; set; } //EmpName
        public string email { get; set; }
        public double esalary { get; set; } //EmpSalaryDetails

        [ForeignKey("mans")]
        public int ManagerId { get; set; }
        public Managers mans { get; set; }
    }
}
