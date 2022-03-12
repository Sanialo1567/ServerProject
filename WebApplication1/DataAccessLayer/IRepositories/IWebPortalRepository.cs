using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IWebPortalRepository
    {
        Task<IEnumerable<WebPortalEntityModel>> GetAllAsync();
        Task<IEnumerable<WebPortalEntityModel>> FindByConditionAsync(Expression<Func<WebPortalEntityModel, bool>> expression);
        Task<WebPortalEntityModel> FindByIdAsync(Guid id);

        Task<WebPortalEntityModel> CreateAsync(WebPortalEntityModel item);

        void Update(WebPortalEntityModel item);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<WebPortalEntityModel> items);
    }
}
