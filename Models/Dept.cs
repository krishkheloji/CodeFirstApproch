using System.ComponentModel.DataAnnotations;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Dept
    {
        [Key]
        public int Did { get; set; }
        public string Dname { get; set; }

        public List<Emp> emps { get; set; }
    }
}
