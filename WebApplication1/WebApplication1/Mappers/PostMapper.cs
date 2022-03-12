using WebApplication1.ViewModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace WebApplication1.Mappers
{
    public class PostMapper : BaseMapper<PostViewModel, PostDtoModel>
    {
        protected override Mapper VMModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostViewModel, PostDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Text, y => y.MapFrom(x => x.Text))
                   .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId)));

            return new Mapper(config);
        }

        protected override Mapper DtoModelToVMModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostDtoModel, PostViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Text, y => y.MapFrom(x => x.Text))
                   .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId)));

            return new Mapper(config);
        }
    }
}
