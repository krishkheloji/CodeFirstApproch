namespace JunBatchCodeFirstApproachImpl.Models
{
    public class StudentModel
    {
        public int Sid { get; set; }
        public string Sname { get; set; }
        public string Scourse { get; set; }
        public double Fees { get; set; }
        public IFormFile Sphoto { get; set; }
    }
}
