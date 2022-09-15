using fiztestone.Models;
namespace fiztestone.Services
{
    public interface ICoursesService
    {
        Task<List<Course>> GetCourses();
        Task<IEnumerable<Module>> GetModules();
        Task<IEnumerable<Course>> BuildCourseTree();
    }
}
