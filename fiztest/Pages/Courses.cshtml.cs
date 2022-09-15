using fiztestone.Models;
using fiztestone.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Specialized;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Web;

namespace fiztest.Pages
{
    public class GetCourseRequest
    {
        [BindProperty(SupportsGet = true)]
        public string? Subject { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Grade { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Genre { get; set; }
    }
    public class CoursesModel : PageModel
    {

        private readonly ICoursesService _courseService; 
        public IEnumerable<Course> Courses;
        public string jCourses = string.Empty;
        public GetCourseRequest request { get; set; }

        public CoursesModel(ICoursesService coursesService)
        {
            _courseService = coursesService;
        }
        public async Task OnGet()
        {
            var data = Request.QueryString;
            String querystring = String.Empty;
            int iqs = data.HasValue?data.Value.IndexOf('?'):-1;
             if (iqs >= 0)
            {
                querystring = HttpUtility.UrlDecode(data.Value.Substring(iqs + 1));
            }
            
            Courses = await _courseService.BuildCourseTree();
            NameValueCollection pars = HttpUtility.ParseQueryString(querystring);
            GetCourseRequest request = new GetCourseRequest();
            string[] filter = new string[] { "", "", "" };
            int i = 0;
            foreach (string p in pars.AllKeys)
            {

                filter[i] = HttpUtility.UrlDecode(pars[p]);
                i++;
            }
            
            Courses = Courses.Where(c => c.Subject.StartsWith(filter[0], StringComparison.CurrentCultureIgnoreCase))
                            .Where(c => c.Grade.ToString().StartsWith(filter[1], StringComparison.CurrentCultureIgnoreCase))
                            .Where(c => c.Genre.ToString().StartsWith(filter[2], StringComparison.CurrentCultureIgnoreCase));
                
            jCourses = JsonSerializer.Serialize(Courses);
        }
    }
}
