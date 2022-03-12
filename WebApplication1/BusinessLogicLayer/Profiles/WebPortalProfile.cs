using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using DataAccessLayer.Services;

namespace BusinessLogicLayer.Profiles
{
    public class WebPortalProfile : BaseProfile<WebPortalDtoModel, WebPortalEntityModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public WebPortalProfile(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WebPortalDtoModel, WebPortalEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                   .ForMember(x => x.OwnerId, y => y.MapFrom(x => x.OwnerId))
                   .ForMember(x => x.CathegoryId, y => y.MapFrom(x => x.CathegoryId)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WebPortalEntityModel, WebPortalDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                   .ForMember(x => x.OwnerId, y => y.MapFrom(x => x.OwnerId))
                   .ForMember(x => x.CathegoryId, y => y.MapFrom(x => x.CathegoryId)));

            return new Mapper(config);
        }
    }
}
