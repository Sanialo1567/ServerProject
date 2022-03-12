using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Profiles
{
    public class UserProfile : BaseProfile<UserDtoModel, UserEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDtoModel, UserEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                   .ForMember(x => x.Mail, y => y.MapFrom(x => x.Mail))
                   .ForMember(x => x.Role, y => y.MapFrom(x => x.Role))
                   .ForMember(x => x.Password, y => y.MapFrom(x => x.Password)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserEntityModel, UserDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                   .ForMember(x => x.Mail, y => y.MapFrom(x => x.Mail))
                   .ForMember(x => x.Role, y => y.MapFrom(x => x.Role))
                   .ForMember(x => x.Password, y => y.MapFrom(x => x.Password)));

            return new Mapper(config);
        }
    }
}
