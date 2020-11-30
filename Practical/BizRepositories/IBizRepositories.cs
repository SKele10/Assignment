using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical.BizRepositories
{
    public interface IBizRepositories<TEntity, in TPk> where TEntity : class
    {
        List<TEntity> GetData();
        TEntity GetData(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        bool Delete(TPk id);
    }
}
