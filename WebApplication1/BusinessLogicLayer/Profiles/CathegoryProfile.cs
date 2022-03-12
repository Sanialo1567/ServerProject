using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Profiles
{
    public class CathegoryProfile : BaseProfile<CathegoryDtoModel, CathegoryEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CathegoryDtoModel, CathegoryEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CathegoryEntityModel, CathegoryDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description)));

            return new Mapper(config);
        }
    }
}
