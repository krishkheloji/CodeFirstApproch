using System.ComponentModel.DataAnnotations;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Role
    {
        [Key]
        public int Rid { get; set; }
        public string Rname { get; set; }

        public List<Emp> emps { get; set; }
    }
}
