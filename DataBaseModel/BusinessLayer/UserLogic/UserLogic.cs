using BusinessLayer.DTOs;
using Dal.Repositories;

namespace BusinessLayer.UserLogic
{
    public interface IUserLogic
    {
        UserDto Get(int id);
        UserDto Get();
        UserDto Create(UserDto user);
        UserDto Update(UserDto user);
    }

    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDto Get(int id)
        {
            return _userRepository.Get(id);
        }

        public UserDto Get()
        {
            return _userRepository.Get();
        }

        public UserDto Create(UserDto user)
        {
            if (user != null)
            {
                user = _userRepository.Add(user);
            }
            return user;
        }

        public UserDto Update(UserDto user)
        {
            if (user != null)
            {
                user = _userRepository.Update(user);
            }
            return user;
        }
    }
}
