using EDSystem.Data;
using EDSystem.Models;
using EDSystem.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace EDSystem.Services
{
    public class CourseService : ICourse
    {
        private readonly ApplicationDbContext _context;
        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddCourse(Course ev)
        {
            await _context.Course.AddAsync(ev);
            await _context.SaveChangesAsync();
            return "Course Added Succesfully";
        }

        public async Task<bool> DeleteCourse(Course ev)
        {
            _context.Course.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<Course> GetCourse(Guid id)
        {
            return await _context.Course.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateCourse(Course ev)
        {
            _context.Course.Update(ev);
            await _context.SaveChangesAsync();
            return "Course Updated Succesfully";
        }
    }
}
