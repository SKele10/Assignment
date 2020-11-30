using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practical.Models;
using Practical.BizRepositories;

namespace Practical.BizRepositories
{
    public class StudentCourseRepository : IBizRepositories<StudentCourse, int>
    {
        PracticalDbContext ctx;
        public StudentCourseRepository()
        {
            ctx = new PracticalDbContext();
        }
        public StudentCourse Create(StudentCourse entity)
        {
            entity = ctx.studentCourses.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.studentCourses.Find(id);
            if (res != null)
            {
                ctx.studentCourses.Remove(res);
                ctx.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<StudentCourse> GetData()
        {
            var res = ctx.studentCourses.ToList();
            return res;
        }

        public StudentCourse GetData(int id)
        {
            var res = ctx.studentCourses.Find(id);
            return res;
        }

        public StudentCourse Update(int id, StudentCourse entity)
        {
            var res = ctx.studentCourses.Find(id);
            if (res != null)
            {
                res.Status = res.Status;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}