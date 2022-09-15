using Microsoft.AspNetCore.Mvc;
using fiztestone.Services;
using fiztestone.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;


namespace fiztestone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private  ICoursesService _courseService;
        public CoursesController(ICoursesService courseService)
        {
            _courseService =courseService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Course>> GetAll()
        {
            var result = await _courseService.BuildCourseTree();//await _courseService.GetModules();
            return result;
        }
        
        
        
    }
}
