using FootMark.Core.Entities.Users;
using FootMark.Domain.Repositories.Users;
using FootMark.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Application.Interfaces.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public string ErrorMessage { get; private set; }

        public async Task<bool> AddAsync(UserDto userDto)
        {
            try
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
                var result = await _userRepository.Add(obj);
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var result = await _userRepository.Delete(id);
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

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

        public async Task<bool> UpdateAsync(UserDto userDto)
        {
            try
            {
                var obj = new AppUser();
                obj.Id = userDto.Id;
                obj.FirstName = userDto.FirstName;
                obj.UserName = userDto.Email;
                obj.LastName = userDto.LastName;
                obj.PhoneNumber = userDto.PhoneNumber;
                obj.City = userDto.City;
                obj.State = userDto.State;
                obj.Zip = userDto.Zip;
                var result = await _userRepository.Update(obj);
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
    }
}
