using FootMark.Domain.Entities.Users;
using FootMark.Repositories.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Services.Interfaces.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public string ErrorMessage { get; private set; }

        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            var obj = new AppUser();
            obj.FirstName = userDto.FirstName;
            obj.UserName = userDto.Email;
            obj.LastName = userDto.LastName;
            obj.Email = userDto.Email;
            obj.PhoneNumber = userDto.PhoneNumber;
            obj.City = userDto.City;
            obj.State = userDto.State;
            obj.Zip = userDto.Zip;
            await _userRepository.Add(obj);
            return userDto;

        }

        public Task<UserDto> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        //public async Task<UserDto> DeleteAsync(string id)
        //{
        //    //UserDto user = await _userRepository.Delete(id);
        //    return user;
        //}

        public async Task<List<UserDto>> GetAllAsync()
        {
            var userList = new List<UserDto>();
            var result = await _userRepository.GetAll();
            foreach (var item in result)
            {
                userList.Add(new UserDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber

                });
            }
            return userList;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var result = await _userRepository.GetById(id);
            var userDM = new UserDto();
            userDM.Id = result.Id;
            userDM.FirstName = result.FirstName;
            userDM.Email = result.Email;
            userDM.LastName = result.LastName; ;
            userDM.PhoneNumber = result.PhoneNumber;

            return userDM;
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            var obj = new AppUser();
            obj.FirstName = userDto.FirstName;
            obj.UserName = userDto.Email;
            obj.LastName = userDto.LastName;
            obj.UserName = userDto.Email;
            obj.PhoneNumber = userDto.PhoneNumber;
            obj.City = userDto.City;
            obj.State = userDto.State;
            obj.Zip = userDto.Zip;
            await _userRepository.Update(obj);
            return userDto;

        }
    }
}
