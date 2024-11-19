using Microsoft.EntityFrameworkCore;
using StudentCRUD.Context;
using StudentCRUD.Models;
using StudentCRUD.RequestResponse;

namespace StudentCRUD.Service
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _context;
        public StudentService(StudentContext context)
        {
            _context = context;
        }

        //add
        public async Task<string> AddStudent(Response student)
        {
            StudentEntity obj = new StudentEntity()
            {
                Id = student.StudentId,
                Name = student.StudentName,
                Mobile = student.StudentMobile,
            };
            _context.Students.Add(obj);
            await _context.SaveChangesAsync();
            return "Added";
        }

        //get all
        public async Task<List<Response>> GetStudents()
        {
            var res = await _context.Students.Select(item => new Response
            {
                StudentId = item.Id,
                StudentName = item.Name,
                StudentMobile = item.Mobile,
            }).ToListAsync();
            return res;
        }

        //get single
        public async Task<Response> GetStudentById(int id)
        {
            var res = await _context.Students.Where(item => item.Id == id).Select(item => new Response
            {
                StudentId = item.Id,
                StudentName = item.Name,
                StudentMobile = item.Mobile
            }).FirstOrDefaultAsync();
            return res;
        }

        //delete
        public async Task<string> DeleteStudentById(int id)
        {
            var res = await _context.Students.Where(item => item.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                _context.Students.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            return null;
        }

        //update
        public async Task<string> UpdateStudent(int id, Response student)
        {
            var res = await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(res != null)
            {
                res.Name = student.StudentName;
                res.Mobile = student.StudentMobile;

                //_context.Students.AddOrUpdate(res);
                await _context.SaveChangesAsync();
                return "Updated";
            }
            return null;
        }
    }
}
