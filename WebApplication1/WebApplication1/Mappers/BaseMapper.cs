using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Mappers
{
    public abstract class BaseMapper<T, E>
    {
        protected abstract Mapper VMModelToDtoModelMapper();
        protected abstract Mapper DtoModelToVMModelMapper();

        public E mapToDto(T value)
        {
            var mapper = VMModelToDtoModelMapper();
            return mapper.Map<T, E>(value);
        }

        public T mapToVM(E value)
        {
            var mapper = DtoModelToVMModelMapper();
            return mapper.Map<E, T>(value);
        }

        public IEnumerable<T> mapListToVM(IEnumerable<E> values)
        {
            var mapper = DtoModelToVMModelMapper();

            IList<T> listDto = new List<T>()
            {
                mapper.Map<E, T>(values.FirstOrDefault())
            };

            int i = 0;
            foreach (var avail in values)
            {
                if (i != 0)
                {
                    T dto = mapper.Map<E, T>(avail);
                    listDto.Add(dto);
                }
                i++;
            }
            return listDto;
        }

        public IEnumerable<T> mapListToDto(IEnumerable<E> values)
        {
            var mapper = VMModelToDtoModelMapper();

            IList<T> listEM = new List<T>()
            {
                mapper.Map<E, T>(values.FirstOrDefault())
            };

            int i = 0;
            foreach (var avail in values)
            {
                if (i != 0)
                {
                    T em = mapper.Map<E, T>(avail);
                    listEM.Add(em);
                }
                i++;
            }
            return listEM;
        }
    }
}
