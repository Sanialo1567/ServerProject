using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IPostService
    {
        Task<Guid> CreatePost(PostDtoModel postDto);

        Task<IEnumerable<PostDtoModel>> GetAllPosts();

        Task<IEnumerable<PostDtoModel>> GetPostByCondition(Expression<Func<PostEntityModel, bool>> expression);
    }
}
