using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;

namespace Application
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUserRepository Get_userRepository()
        {
            return _userRepository;
        }

        public async Task<int> CreateUserAsync(string name, string email, string gender, int age)
        {
            var user = new User(name, email, gender, age);
            return await _userRepository.AddAsync(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<int> UpdateUserAsync(int id, string name, string email, string gender, int age)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null) { return 0; }
            user.Update(name, email, gender, age);
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null) { return false;}
            return await _userRepository.DeleteAsync(user);
        }
    }
}
