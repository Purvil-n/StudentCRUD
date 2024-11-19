using StudentCRUD.RequestResponse;

namespace StudentCRUD.Service
{
    public interface IStudentService
    {
        Task<List<Response>> GetStudents();
        Task<Response> GetStudentById(int id);
        Task<string> AddStudent(Response student);
        Task<string> UpdateStudent(int id, Response student);
        Task<string> DeleteStudentById(int id);
    }
}
