using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practical.Models;

namespace Practical.BizRepositories
{
    public class StudentRepository : IBizRepositories<Student, int>
    {
        PracticalDbContext ctx;
        public StudentRepository()
        {
            ctx = new PracticalDbContext();
        }
        public Student Create(Student entity)
        {
            entity = ctx.Students.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Students.Find(id);
            if (res != null)
            {
                ctx.Students.Remove(res);
                ctx.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<Student> GetData()
        {
            var res = ctx.Students.ToList();
            return res;
        }

        public Student GetData(int id)
        {
            var res = ctx.Students.Find(id);
            return res;
        }

        public Student Update(int id, Student entity)
        {
            var res = ctx.Students.Find(id);
            if(res != null)
            {
                res.Address = entity.Address;
                res.AreaOfInterests = entity.AreaOfInterests;
                res.City = entity.City;
                res.DateOfBirth = entity.DateOfBirth;
                res.Email = entity.Email;
                res.Mobile = entity.Mobile;
                res.StudentId = entity.StudentId;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}