using JunBatchCodeFirstApproachImpl.Models;

namespace JunBatchCodeFirstApproachImpl.Repository
{
    public interface IEmpService
    {
        void AddEmp(StudentModel e);
        List<Student> displayEmp();
        void DeleteEmp(int id);

        Student findEmpById(int id);
        void UpdateEmpDetails(Student e);
    }
}
