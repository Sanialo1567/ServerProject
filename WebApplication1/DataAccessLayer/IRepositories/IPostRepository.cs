using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostEntityModel>> GetAllAsync();
        Task<IEnumerable<PostEntityModel>> FindByConditionAsync(Expression<Func<PostEntityModel, bool>> expression);
        Task<PostEntityModel> FindByIdAsync(Guid id);

        Task<PostEntityModel> CreateAsync(PostEntityModel item);

        void Update(PostEntityModel item);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<PostEntityModel> items);
    }
}
