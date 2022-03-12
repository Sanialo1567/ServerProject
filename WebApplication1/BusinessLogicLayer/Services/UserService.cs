using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Profiles;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;


namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserProfile profile = new();

        public UserService(IUnitOfWork service)
        {
            _unitOfWork = service;
        }

        public async Task<Guid> CreateUser(UserDtoModel userDto)
        {
            UserEntityModel userEM = profile.mapToEM(userDto);
            userEM = await _unitOfWork.Users.CreateAsync(userEM);
            _unitOfWork.Save();

            return userEM.Id;
        }

        public async Task<IEnumerable<UserDtoModel>> GetAllUsers()
        {
            return profile.mapListToDto(await _unitOfWork.Users.GetAllAsync());
        }

        public async Task<UserDtoModel> GetUserById(Guid id)
        {
            return profile.mapToDto(await _unitOfWork.Users.FindByIdAsync(id));
        }

        public async Task<bool> UpdateUser(UserDtoModel userDto)
        {
            try
            {
                UserEntityModel userEM = profile.mapToEM(userDto);
                _unitOfWork.Users.Delete(userEM.Id);
                _unitOfWork.Users.CreateAsync(userEM);
                await _unitOfWork.SaveAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
