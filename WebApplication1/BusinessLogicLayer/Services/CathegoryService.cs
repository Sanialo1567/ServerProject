using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Profiles;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CathegoryService : ICathegoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CathegoryProfile profile = new();

        public CathegoryService(IUnitOfWork service)
        {
            _unitOfWork = service;
        }

        public async Task<Guid> CreateCathegory(CathegoryDtoModel cathegoryDto)
        {
            CathegoryEntityModel cathegoryEM = profile.mapToEM(cathegoryDto);
            cathegoryEM = await _unitOfWork.Cathegories.CreateAsync(cathegoryEM);
            await _unitOfWork.SaveAsync();

            return cathegoryEM.Id;
        }

        public async Task<IEnumerable<CathegoryDtoModel>> GetCathegories()
        {
            IEnumerable<CathegoryDtoModel> cathegoriesDto= profile.mapListToDto(await _unitOfWork.Cathegories.GetAllAsync());
            return cathegoriesDto;
        }

        public async Task<IEnumerable<CathegoryDtoModel>> GetCathegoryByCondition(Expression<Func<CathegoryEntityModel, bool>> expression)
        {
            return profile.mapListToDto(await _unitOfWork.Cathegories.FindByConditionAsync(expression));
        }

        public async Task<CathegoryDtoModel> GetCathegoryById(Guid id)
        {
            CathegoryDtoModel cathegoryDto = profile.mapToDto(await _unitOfWork.Cathegories.FindByIdAsync(id));
            if (cathegoryDto == null)
                return null;

            return cathegoryDto;
        }

        public Guid UpdateCathegory(CathegoryDtoModel cathegoryDto)
        {
            CathegoryEntityModel cathegoryEntityModel = profile.mapToEM(cathegoryDto);
            _unitOfWork.Cathegories.Delete(cathegoryEntityModel.Id);
            _unitOfWork.Cathegories.CreateAsync(cathegoryEntityModel);
            _unitOfWork.Save();

            return cathegoryEntityModel.Id;
        }
    }
}
