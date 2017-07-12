using System;
using System.Data.Entity.Migrations;
using System.Linq;
using BusinessLayer.DTOs;
using Dal.Context;
using DBModelLib.Entities;

namespace Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILittleHelperContext _context;
        public UserRepository(ILittleHelperContext context)
        {
            _context = context;
        }

        public UserDto Get()
        {
            return AutoMapper.Mapper.Map<UserDto>(_context.User.ToList());
        }


        public UserDto Get(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id) as User;

            if (user != null)
            {
                return AutoMapper.Mapper.Map<UserDto>(user);
            }

            return null;
        }

        public UserDto Update(UserDto user)
        {
            if (user == null) return null;

            var userToUpdate = _context.User.SingleOrDefault(u => u.Id == user.Id);

            _context.User.AddOrUpdate(userToUpdate);
            _context.SaveChanges();

            return AutoMapper.Mapper.Map<UserDto>(userToUpdate);
        }

        public UserDto Add(UserDto user)
        {
            if (user == null) return null;

            var userToAdd = AutoMapper.Mapper.Map<User>(user);

            _context.User.Add(userToAdd);
            _context.SaveChanges();

            return AutoMapper.Mapper.Map<UserDto>(userToAdd);
        }

        public bool UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
