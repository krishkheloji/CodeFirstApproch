namespace JunBatchCodeFirstApproachImpl.DTO
{
    public class EmpAddDTO
    {
        public int eid { get; set; }
        public string ename { get; set; } //EmpName
        public string email { get; set; }
        public double esalary { get; set; } //EmpSalaryDetails
        public int ManagerId { get; set; }
    }
}
