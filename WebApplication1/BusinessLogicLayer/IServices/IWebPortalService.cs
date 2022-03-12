using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.IServices
{
    public interface IWebPortalService
    {
        Task<IEnumerable<WebPortalDtoModel>> GetAllWebPortals();

        Task<Guid> CreateWebPortal(WebPortalDtoModel webPortalDto);

        Task<WebPortalDtoModel> GetWebPortalById(Guid id, Guid userId);

        Task<IEnumerable<WebPortalDtoModel>> GetWebPortalByCondition(Expression<Func<WebPortalEntityModel, bool>> expression);
    }
}
