using DevOpsDemo.Models;

namespace DevOpsDemo.Repositories
{
    public interface IUsersRepo
    {
        public Task<ICollection<User>?> GetAllUsers();
        public Task<User?> GetUserById(Guid id);
        public Task<User?> CreateUser(User user);
        public Task<User?> UpdateUser(User user);
        public Task<ICollection<User>?> DeleteUser(Guid id);
    }
}
