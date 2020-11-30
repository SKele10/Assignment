using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practical.Models;

namespace Practical.BizRepositories
{
    public class CourseRepository : IBizRepositories<Course, int>
    {
        PracticalDbContext ctx;
        public CourseRepository()
        {
            ctx = new PracticalDbContext();
        }
        public Course Create(Course entity)
        {
            entity = ctx.Courses.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Courses.Find(id);
            if (res != null)
            {
                ctx.Courses.Remove(res);
                ctx.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<Course> GetData()
        {
            var res = ctx.Courses.ToList();
            return res;
        }

        public Course GetData(int id)
        {
            var res = ctx.Courses.Find(id);
            return res;
        }

        public Course Update(int id, Course entity)
        {
            var res = ctx.Courses.Find(id);
            if (res != null)
            {
                res.CourseArea = entity.CourseArea;
                res.CourseName = entity.CourseName;
                res.Modules = entity.Modules;
                res.Price = entity.Price;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}