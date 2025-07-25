using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using JunBatchCodeFirstApproachImpl.Repository;

namespace JunBatchCodeFirstApproachImpl.Service
{
    public class EmpService : IEmpService
    {
        ApplicationDbContext db;
        IWebHostEnvironment env;
        public EmpService(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void AddEmp(StudentModel e)
        {
            var path = env.WebRootPath;
            var filepath = "Content/Images/" + e.Sphoto.FileName;
            var fpath = Path.Combine(path, filepath);
            FileUpload(e.Sphoto, fpath);

            var s = new Student()
            {
                Sname=e.Sname,
                Scourse=e.Scourse,
                Fees=e.Fees,
                Sphoto=filepath
            };
            db.students.Add(s);
            db.SaveChanges();
        }
        public void FileUpload(IFormFile file,string path)
        {
            FileStream stream = new FileStream(path,FileMode.Create);
            file.CopyTo(stream);
        }

        public List<Student> displayEmp()
        {
            var data=db.students.ToList();
            return data;
        }

        public void DeleteEmp(int id)
        {
            var d=db.students.Find(id);
            db.students.Remove(d);
            db.SaveChanges();
        }

        public Student findEmpById(int id)
        {
            var data=db.students.Find(id);
            return data;
        }

        public void UpdateEmpDetails(Student e)
        {
            db.students.Update(e);
            db.SaveChanges();
        }
    }
}
