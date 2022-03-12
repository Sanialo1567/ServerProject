using WebApplication1.ViewModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace WebApplication1.Mappers
{
    public class UserMapper : BaseMapper<UserViewModel, UserDtoModel>
    {
        protected override Mapper VMModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                   .ForMember(x => x.Mail, y => y.MapFrom(x => x.Mail))
                   .ForMember(x => x.Role, y => y.MapFrom(x => x.Role))
                   .ForMember(x => x.Password, y => y.MapFrom(x => x.Password)));

            return new Mapper(config);
        }

        protected override Mapper DtoModelToVMModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDtoModel, UserViewModel>()
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
