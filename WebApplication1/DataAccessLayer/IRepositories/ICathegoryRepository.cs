using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICathegoryRepository
    {
        Task<IEnumerable<CathegoryEntityModel>> GetAllAsync();
        Task<IEnumerable<CathegoryEntityModel>> FindByConditionAsync(Expression<Func<CathegoryEntityModel, bool>> expression);
        Task<CathegoryEntityModel> FindByIdAsync(Guid id);

        Task<CathegoryEntityModel> CreateAsync(CathegoryEntityModel item);

        void Update(CathegoryEntityModel item);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<CathegoryEntityModel> items);
    }
}
