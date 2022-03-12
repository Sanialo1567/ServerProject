using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.IServices
{
    public interface IUserService
    {
        Task<Guid> CreateUser(UserDtoModel userDto);
        Task<bool> UpdateUser(UserDtoModel userDto);

        Task<IEnumerable<UserDtoModel>> GetAllUsers();

        Task<UserDtoModel> GetUserById(Guid id);
    }
}
