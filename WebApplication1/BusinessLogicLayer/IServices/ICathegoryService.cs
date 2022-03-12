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
    public interface ICathegoryService
    {
        Task<Guid> CreateCathegory(CathegoryDtoModel cathegoryDto);


        Task<IEnumerable<CathegoryDtoModel>> GetCathegories();

        Task<CathegoryDtoModel> GetCathegoryById(Guid id);

        Guid UpdateCathegory(CathegoryDtoModel cathegoryDto);

        Task<IEnumerable<CathegoryDtoModel>> GetCathegoryByCondition(Expression<Func<CathegoryEntityModel, bool>> expression);
    }
}
