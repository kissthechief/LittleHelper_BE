using BusinessLayer.DTOs;

namespace Dal.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Collects all users
        /// </summary>
        /// <returns>A unfiltered list of all users</returns>
        UserDto Get();

        /// <summary>
        /// Gets an user by its id
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        UserDto Get(int id);

        /// <summary>
        /// Check if a user exists or not
        /// </summary>
        /// <param name="email">The email of the user. Email is uniqe</param>
        /// <returns>True means the user exists</returns>
        bool UserExists(string email);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user">The user to update</param>
        /// <returns>The updated users</returns>
        UserDto Update(UserDto user);
        
        /// <summary>
        /// Create a new user. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        UserDto Add(UserDto user);
    }
}