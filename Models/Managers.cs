using System.ComponentModel.DataAnnotations;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Managers
    {
        [Key]
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

        public List<Employee> employees { get; set; }
    }
}
