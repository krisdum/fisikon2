using fiztestone.Models;
using fiztestone.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace fiztest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICoursesService _courseService;
        public IEnumerable<Course> Courses;
        public string jCourses = string.Empty;

        public IndexModel(ICoursesService coursesService)
        {
            _courseService = coursesService;
        }
        public async Task OnGet()
        {

            Courses = await _courseService.BuildCourseTree();
            jCourses = JsonSerializer.Serialize(Courses);
        }
    }
}