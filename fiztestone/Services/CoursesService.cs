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
namespace fiztestone.Services
{
    public class CoursesService:ICoursesService
    {
        private readonly IDapper _dapper;
        public CoursesService(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<List<Course>> GetCourses()
        {
            var result = await Task.FromResult(_dapper.GetList<Course>($"Select * from [Courses]", null, commandType: CommandType.Text));
            return result;
        }
        public async Task<IEnumerable<Module>> GetModules()
        {
            var result = await Task.FromResult(_dapper.GetList<Module>($"Select * from [Modules] ", null, commandType: CommandType.Text));
            return result;
        }
        public async Task<IEnumerable<Course>> BuildCourseTree()
        {
            var courses=(await GetCourses()).OrderBy(c=>c.Title);
            //var modules = await GetModules();
            foreach(var course in courses)
            {
                course.Modules = BuildTree((await GetModules()).OrderBy(m=>m.Order), null).Where(x => x.CourseId == course.Id).ToList();
                //foreach(var module in course.Modules)
                    //BuildTree(course.Modules, null);
            }
            return courses;
        }
        private IEnumerable<Module> BuildTree(IEnumerable<Module> moduleTree, int? parent)
        {
            return moduleTree.Where(x => x.ParentId == parent).Select(x => new Module
            {
                Id = x.Id,
                CourseId = x.CourseId,
                Title = x.Num+" "+x.Title,
                Order = x.Order,
                Num = x.Num,
                ChildModules = BuildTree(moduleTree, x.Id)
            }).ToList().OrderBy(m=>m.Order);
        }

    }
}
