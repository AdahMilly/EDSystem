using EDSystem.Models;

namespace EDSystem.Services.IService
{
    public interface ICourse
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourse(Guid id);
        Task<string> AddCourse(Course ev);
        Task<string> UpdateCourse(Course ev);
        Task<bool> DeleteCourse(Course ev);
    }
}
