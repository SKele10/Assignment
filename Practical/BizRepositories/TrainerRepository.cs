using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practical.Models;

namespace Practical.BizRepositories
{
    public class TrainerRepository : IBizRepositories<Trainer, int>
    {
        PracticalDbContext ctx;
        public TrainerRepository()
        {
            ctx = new PracticalDbContext();
        }
        public Trainer Create(Trainer entity)
        {
            entity = ctx.Trainers.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Trainers.Find(id);
            if (res != null)
            {
                ctx.Trainers.Remove(res);
                ctx.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<Trainer> GetData()
        {
            var res = ctx.Trainers.ToList();
            return res;
        }

        public Trainer GetData(int id)
        {
            var res = ctx.Trainers.Find(id);
            return res;
        }

        public Trainer Update(int id, Trainer entity)
        {
            var res = ctx.Trainers.Find(id);
            if (res != null)
            {
                res.TrainerName = entity.TrainerName;
                res.ExpertiseArea = entity.ExpertiseArea;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}