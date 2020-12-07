using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryMS.Domain;

namespace InventoryMS.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Status> AddUser(UserDto userDto)
        {
            Status status = new Status();
            bool isExist = _userRepository.IsUserExist(userDto.UserName);
            if (!isExist)
            {
                User user = _mapper.Map<User>(userDto);
                user.Adduser(user);
                user = await _userRepository.AddUser(user);
                if (user != null)
                {
                    return status = new Status() {IsSuccess = true, SuccessMessage = "User saved successfully"};
                }
                else
                {
                    return status = new Status() {IsSuccess = false, ErrorMessage = "Something went wrong"};
                }
            }
            else
            {
                return status = new Status() { IsSuccess = false, ErrorMessage = "User already exist." };
            }

        }

        public Status Login(string userName, string password)
        {
            Status status = new Status();

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                bool isSuccess = _userRepository.Login(userName, password);

                if (isSuccess)
                {
                    return status = new Status() { IsSuccess = true, SuccessMessage = "Login successfully" };
                }
                else
                {
                    return status = new Status() { IsSuccess = false, ErrorMessage = "Please enter valid credential" };
                }
            }

            return null;
        }
    }
}
