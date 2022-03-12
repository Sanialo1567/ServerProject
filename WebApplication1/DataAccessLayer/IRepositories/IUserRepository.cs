using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntityModel>> GetAllAsync();
        Task<IEnumerable<UserEntityModel>> FindByConditionAsync(Expression<Func<UserEntityModel, bool>> expression);
        Task<UserEntityModel> FindByIdAsync(Guid id);

        Task<UserEntityModel> CreateAsync(UserEntityModel item);

        void Update(UserEntityModel item);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<UserEntityModel> items);
    }
}
